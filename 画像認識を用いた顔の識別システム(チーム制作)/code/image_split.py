#ドライブをマウント
from google.colab import drive
drive.mount('/content/drive')

#ライブラリのインポート
import glob
from facenet_pytorch import MTCNN
import os
from PIL import Image
mtcnn = MTCNN()

#画像の切り抜き
image_dir = '/content/drive/Shareddrives/dsx2022_13/young_s_png1'
for i, path in enumerate(glob.glob(os.path.join(image_dir,"*.png"))):
  if(i%100==0):
    print(i)
  img = Image.open(path)
  img_cropped = mtcnn(img, save_path='/content/drive/MyDrive/dsx2022/DSX_task/images/young_smile/{}.png'.format(str(i))) # 画像と保存先を渡す
  if i>5000:
    break
print("breakしたよ")
image_dir = '/content/drive/Shareddrives/dsx2022_13/young_ns_png1'
for i, path in enumerate(glob.glob(os.path.join(image_dir,"*.png"))):
  if(i%100==0):
    print(i)
  img = Image.open(path)
  img_cropped = mtcnn(img, save_path='/content/drive/MyDrive/dsx2022/DSX_task/images/young_not_smile/{}.png'.format(str(i))) # 画像と保存先を渡す
  if i>5000:
    break
print("breakしたよ")
image_dir = '/content/drive/Shareddrives/dsx2022_13/old_s'
for i, path in enumerate(glob.glob(os.path.join(image_dir,"*.png"))):
  if(i%100==0):
    print(i)
  img = Image.open(path)
  img_cropped = mtcnn(img, save_path='/content/drive/MyDrive/dsx2022/DSX_task/images/old_smile/{}.png'.format(str(i))) # 画像と保存先を渡す
  if i>5000:
    break
print("breakしたよ")
image_dir = '/content/drive/Shareddrives/dsx2022_13/old_ns'
for i, path in enumerate(glob.glob(os.path.join(image_dir,"*.png"))):
  if(i%100==0):
    print(i)
  img = Image.open(path)
  img_cropped = mtcnn(img, save_path='/content/drive/MyDrive/dsx2022/DSX_task/images/old_not_smile/{}.png'.format(str(i))) # 画像と保存先を渡す
  if i>5000:
    break
print("breakしたよ")

#検証用画像の切り抜き
image_dir = '/content/drive/MyDrive/dsx2022/DSX_task/images_test'
for i, path in enumerate(glob.glob(os.path.join(image_dir,"*.jpg"))):
    img = Image.open(path)
    img_cropped = mtcnn(img, save_path='/content/drive/MyDrive/dsx2022/DSX_task/images/test/{}.png'.format(str(i))) # 画像と保存先を渡す
