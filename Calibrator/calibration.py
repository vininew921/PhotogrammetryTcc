import getopt
import json
import sys
import cv2
import numpy as np
import os
import glob


def get_checkerboard_points(images_path):
    # Define checkerboard size (calibration images)
    CHECKERBOARD = (9,9)
    criteria = (cv2.TERM_CRITERIA_EPS + cv2.TERM_CRITERIA_MAX_ITER, 30, 0.001)
    
    # Creating vector to store vectors of 3D points for each checkerboard image
    objpoints = []

    # Creating vector to store vectors of 2D points for each checkerboard image
    imgpoints = [] 
    
    
    # Defining the world coordinates for 3D points
    objp = np.zeros((1, CHECKERBOARD[0] * CHECKERBOARD[1], 3), np.float32)
    objp[0,:,:2] = np.mgrid[0:CHECKERBOARD[0], 0:CHECKERBOARD[1]].T.reshape(-1, 2)
    prev_img_shape = None
    
    # Extracting path of individual image stored in a given directory
    images = glob.glob(f'{images_path}/*.png')
    for fname in images:
        img = cv2.imread(fname)
        gray = cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)

        # Find the chess board corners
        # If desired number of corners are found in the image then ret = true
        ret, corners = cv2.findChessboardCorners(gray, CHECKERBOARD, cv2.CALIB_CB_ADAPTIVE_THRESH + cv2.CALIB_CB_FAST_CHECK + cv2.CALIB_CB_NORMALIZE_IMAGE)

        """
        If desired number of corner are detected,
        we refine the pixel coordinates and display 
        them on the images of checker board
        """
        if ret == True:
            objpoints.append(objp)
            # refining pixel coordinates for given 2d points.
            corners2 = cv2.cornerSubPix(gray, corners, (11,11),(-1,-1), criteria)

            imgpoints.append(corners2)
    
            # Draw and display the corners
            img = cv2.drawChessboardCorners(img, CHECKERBOARD, corners2, ret)
    
    ret, mtx, dist, rvecs, tvecs = cv2.calibrateCamera(objpoints, imgpoints, gray.shape[::-1], None, None)
    return ret, mtx, dist, rvecs, tvecs
    
def main(argv):
    images_path = ''
    appid = ''
    opts, args = getopt.getopt(argv, "i:a:", ["images=", "appid="])
    for opt, arg in opts:
        if opt in ("-i", "--images"):
            images_path = arg
        elif opt in ("-a", "--appid"):
            appid = arg

    ret, mtx, dist, rvecs, tvecs = get_checkerboard_points(images_path)

    data =  {
                'ret': ret,
                'mtx': mtx.tolist(),
                'dist': dist.tolist(),
            }

    appdata = os.getenv('APPDATA')

    with open(f'{appdata}\PhotogrammetryTCC\CalibrationResults\{appid}.json', 'w') as file_object:
        json.dump(data, file_object)


    return

if __name__ == "__main__":
    main(sys.argv[1:])