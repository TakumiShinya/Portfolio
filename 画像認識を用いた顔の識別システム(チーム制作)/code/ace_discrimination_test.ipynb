from google.colab import drive
drive.mount('/content/drive')

#ライブラリのインポート
import cv2
from google.colab.patches import cv2_imshow
import os,glob
import numpy as np

#ディレクトリの移動
%cd '/content/drive/MyDrive/dsx2022/DSX_task'
%ls

#正解ラベルの格納
categories = ['young_smile', 'young_not_smile', 'old_smile', 'old_not_smile']
ncategories = len(categories)

nimages_per_label=400
y=np.array([])
imagefilelist=[]

for i,category in enumerate(categories):
  imagefilelist_thiscategory=glob.glob(os.path.join('./images',category,'*.png'))
  imagefilelist.extend(imagefilelist_thiscategory[:nimages_per_label])
  yn=np.ones((nimages_per_label),float)*i
  y=np.append(y,yn)

x=np.zeros((len(imagefilelist),160,160,3),float)

for i,f in enumerate(imagefilelist):
  if(i%100==0):
    print(i)
  im=cv2.imread(f)
  x[i]=im

#配列のshape確認
print(x.shape)
nsample=x.shape[0]
#print(x[0])

print(y.shape)

#ラベルをランダムに並べ替え
p=np.random.permutation(nsample)
x=x[p]
y=y[p]

x=x.reshape(nsample,160,160,3)
x=x/255

#バイナリのクラス行列に変換
from tensorflow.keras.utils import to_categorical

y=to_categorical(y, ncategories)
print(y)

#モデルの訓練
from tensorflow.keras.models import Sequential
from tensorflow.keras.layers import Dense,Conv2D,MaxPooling2D,Dropout,Flatten,BatchNormalization,Activation
#from tensorflow.keras.callbacks import TensorBoard

model=Sequential()
model.add(Conv2D(filters=32,input_shape=(160,160,3),kernel_size=(3,3),
                     strides=(1,1),padding='same',activation='relu'))
model.add(Conv2D(filters=32,kernel_size=(3,3),
                     strides=(1,1),padding='same',activation='relu'))
model.add(MaxPooling2D(pool_size=(2,2)))
model.add(Dropout(0.25))
model.add(Conv2D(filters=64,kernel_size=(3,3),
                     strides=(1,1),padding='same',activation='relu'))
model.add(Conv2D(filters=64,kernel_size=(3,3),
                     strides=(1,1),padding='same',activation='relu'))
model.add(MaxPooling2D(pool_size=(2,2)))
model.add(Dropout(0.25))
print('output_shape(1):',model.output_shape)
model.add(Flatten())
print('output_shape(2):',model.output_shape)
model.add(Dense(units=512,activation='relu'))
model.add(Dropout(0.5))
model.add(Dense(units=ncategories, activation='softmax'))
model.compile(
    optimizer='adam',loss='categorical_crossentropy',metrics=['accuracy']
)
history = model.fit(
    x,y,batch_size=32,epochs=20,validation_split=0.2
)

#モデルの検証
#1番目が真顔、2番目が笑顔
mytestimages=['./images/young_smile/166.png','./images/old_smile/1.png','./images/young_not_smile/554.png','./images/old_not_smile/13.png']
#mytestimages=['./images/test/8.png','./images/test/5.png']
n=len(mytestimages)
test=np.zeros((n,160,160,3))
#print("上から、若い人の笑顔、老人の笑顔、若い人の笑顔じゃない顔、老人の笑顔じゃない顔")
for i in range(n):
  img=cv2.imread(mytestimages[i])
  test[i]=img
  display_png(Image(mytestimages[i]))

test=test/255.

results = model.predict(test)

np.set_printoptions(precision=6, floatmode='fixed', suppress=True)


print("young_s,   young_ns,  old_s,   old_ns")
print(results)
