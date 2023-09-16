import getopt
import json
import sys
import cv2
import numpy as np
import os
import glob

def get_calibration(calibration_id):
	appdata = os.getenv('APPDATA')
	json_calibration = ''

	with open(f'{appdata}\PhotogrammetryTCC\CalibrationResults\{calibration_id}.json', 'r') as file_object:
		json_calibration = json.load(file_object)

	ret = json_calibration['ret']
	mtx = np.array(json_calibration['mtx'])
	dist = np.array(json_calibration['dist'])

	return ret, mtx, dist

def process_images(app_id, ret, mtx, dist):
	appdata = os.getenv('APPDATA')
	images_path = f'{appdata}\PhotogrammetryTCC\TempImages\{app_id}'

	images = glob.glob(f'{images_path}/*.png')
	processed_images_path = os.path.join(images_path, 'processed_images');

	if not os.path.exists(processed_images_path):
		os.mkdir(processed_images_path)

	for image_path in images:
		img = cv2.imread(image_path)
		h, w = img.shape[:2]
		newcameramtx, roi = cv2.getOptimalNewCameraMatrix(mtx, dist, (w, h), 1, (w, h))

		# Undistort image
		dst = cv2.undistort(img, mtx, dist, None, newcameramtx)

		# Crop unwanted pixels
		x, y, w, h = roi
		dst = dst[y:y+h, x:x+w]

		cv2.imwrite(f'{processed_images_path}\{os.path.splitext(os.path.basename(image_path))[0]}.png', dst)

	pass

def main(argv):
	app_id = ''
	calibration_id = ''
	opts, args = getopt.getopt(argv, "a:c:", ["appid=", "calibrationid="])
	for opt, arg in opts:
		if opt in ("-a", "--appid"):
			app_id = arg
		if opt in ("-c", "--calibrationid"):
			calibration_id = arg

	ret, mtx, dist = get_calibration(calibration_id)

	process_images(app_id, ret, mtx, dist)
	return

if __name__ == "__main__":
	main(sys.argv[1:])