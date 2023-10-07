import getopt
import glob
import os
import sys
import numpy as np
import cv2
import matplotlib.pyplot as plt
import json

def common_points(app_id):
    appdata = os.getenv('APPDATA')
    images_path = f'{appdata}\PhotogrammetryTCC\TempImages\{app_id}\processed_images'
    images_match_path = f'{appdata}\PhotogrammetryTCC\TempImages\{app_id}\processed_images\matches'

    if not os.path.exists(images_match_path):
        os.mkdir(images_match_path)

    images = glob.glob(f'{images_path}/*.png')

    common_keypoints = []

    for i in range(len(images) - 1):
        img1 = cv2.medianBlur(cv2.imread(f'{images_path}\{i}.png',cv2.IMREAD_ANYCOLOR), 5)
        img2 = cv2.medianBlur(cv2.imread(f'{images_path}\{i + 1}.png',cv2.IMREAD_ANYCOLOR), 5)

        if img1 is None or img2 is None:
            print('Could not open or find the images!')
            exit(0)

        #-- Step 1: Detect the keypoints using SURF Detector, compute the descriptors
        detector = cv2.SIFT_create()
        keypoints1, descriptors1 = detector.detectAndCompute(img1, None)
        keypoints2, descriptors2 = detector.detectAndCompute(img2, None)
        #-- Step 2: Matching descriptor vectors with a FLANN based matcher
        # Since SURF is a floating-point descriptor NORM_L2 is used
        matcher = cv2.DescriptorMatcher_create(cv2.DescriptorMatcher_FLANNBASED)
        knn_matches = matcher.knnMatch(descriptors1, descriptors2, 2)
        #-- Filter matches using the Lowe's ratio test
        ratio_thresh = 0.5
        good_matches = []
        for m,n in knn_matches:
            if m.distance < ratio_thresh * n.distance:
                good_matches.append(m)
        #-- Draw matches
        img_matches = np.empty((max(img1.shape[0], img2.shape[0]), img1.shape[1]+img2.shape[1], 3), dtype=np.uint8)
        cv2.drawMatches(img1, keypoints1, img2, keypoints2, good_matches, img_matches, flags=cv2.DrawMatchesFlags_NOT_DRAW_SINGLE_POINTS)
        #-- Show detected matches
        #plt.imshow(img_matches,),plt.show()
        # Save matches in an image
        cv2.imwrite(f'{images_match_path}\{i}_{i + 1}.png', img_matches)

        for match in good_matches:
            keypoint1 = keypoints1[match.queryIdx]
            keypoint2 = keypoints2[match.trainIdx]
            common_keypoints.append(
                {
                    'coordinates': 
                    {
                        f'ax': keypoint1.pt[0],
                        f'ay': keypoint1.pt[1],
                        f'bx': keypoint2.pt[0],
                        f'by': keypoint2.pt[1]
                    }, 
                    'image_a': i, 
                    'image_b': i+1
                }) 

        # -- Save common keypoints to a JSON file
        with open(f'{images_path}\common_keypoints.json', 'w') as json_file:
            json.dump(common_keypoints, json_file, indent=4)

def main(argv):
    app_id = ''
    opts, args = getopt.getopt(argv, "a:", ["appid="])
    for opt, arg in opts:
        if opt in ("-a", "--appid"):
            app_id = arg

    common_points(app_id)
    return


if __name__ == "__main__":
    main(sys.argv[1:])