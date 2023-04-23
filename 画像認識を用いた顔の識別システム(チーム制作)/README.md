# 画像認識を用いた顔の識別システム（チーム制作）

## 目次
1.[説明](https://github.com/TakumiShinya/Portfolio/blob/main/%E7%94%BB%E5%83%8F%E8%AA%8D%E8%AD%98%E3%82%92%E7%94%A8%E3%81%84%E3%81%9F%E9%A1%94%E3%81%AE%E8%AD%98%E5%88%A5%E3%82%B7%E3%82%B9%E3%83%86%E3%83%A0(%E3%83%81%E3%83%BC%E3%83%A0%E5%88%B6%E4%BD%9C)/README.md#%E8%AA%AC%E6%98%8E)

2.[制作期間](https://github.com/TakumiShinya/Portfolio/blob/main/%E7%94%BB%E5%83%8F%E8%AA%8D%E8%AD%98%E3%82%92%E7%94%A8%E3%81%84%E3%81%9F%E9%A1%94%E3%81%AE%E8%AD%98%E5%88%A5%E3%82%B7%E3%82%B9%E3%83%86%E3%83%A0(%E3%83%81%E3%83%BC%E3%83%A0%E5%88%B6%E4%BD%9C)/README.md#%E5%88%B6%E4%BD%9C%E6%9C%9F%E9%96%93)

3.[仮説と目的](https://github.com/TakumiShinya/Portfolio/blob/main/%E7%94%BB%E5%83%8F%E8%AA%8D%E8%AD%98%E3%82%92%E7%94%A8%E3%81%84%E3%81%9F%E9%A1%94%E3%81%AE%E8%AD%98%E5%88%A5%E3%82%B7%E3%82%B9%E3%83%86%E3%83%A0(%E3%83%81%E3%83%BC%E3%83%A0%E5%88%B6%E4%BD%9C)/README.md#%E4%BB%AE%E8%AA%AC%E3%81%A8%E7%9B%AE%E7%9A%84)

4.[制作コード](https://github.com/TakumiShinya/Portfolio/tree/main/%E7%94%BB%E5%83%8F%E8%AA%8D%E8%AD%98%E3%82%92%E7%94%A8%E3%81%84%E3%81%9F%E9%A1%94%E3%81%AE%E8%AD%98%E5%88%A5%E3%82%B7%E3%82%B9%E3%83%86%E3%83%A0(%E3%83%81%E3%83%BC%E3%83%A0%E5%88%B6%E4%BD%9C)#%E5%88%B6%E4%BD%9C%E3%82%B3%E3%83%BC%E3%83%89)

5.[使用データ](https://github.com/TakumiShinya/Portfolio/blob/main/%E7%94%BB%E5%83%8F%E8%AA%8D%E8%AD%98%E3%82%92%E7%94%A8%E3%81%84%E3%81%9F%E9%A1%94%E3%81%AE%E8%AD%98%E5%88%A5%E3%82%B7%E3%82%B9%E3%83%86%E3%83%A0(%E3%83%81%E3%83%BC%E3%83%A0%E5%88%B6%E4%BD%9C)/README.md#%E4%BD%BF%E7%94%A8%E3%83%87%E3%83%BC%E3%82%BF)

6.[開発体制](https://github.com/TakumiShinya/Portfolio/blob/main/%E7%94%BB%E5%83%8F%E8%AA%8D%E8%AD%98%E3%82%92%E7%94%A8%E3%81%84%E3%81%9F%E9%A1%94%E3%81%AE%E8%AD%98%E5%88%A5%E3%82%B7%E3%82%B9%E3%83%86%E3%83%A0(%E3%83%81%E3%83%BC%E3%83%A0%E5%88%B6%E4%BD%9C)/README.md#%E9%96%8B%E7%99%BA%E4%BD%93%E5%88%B6)

7.

8.

## 説明

大学の「データサイエンス演習」という授業の一環で制作しました。

5人1組でチームを組んで制作を行い、授業で習った画像認識のプログラムを利用・一部改変し、顔の識別システムを考案しました。

その中でも私は、Google Colaboratoryを用いた顔画像の切り抜きシステムと顔判別システムのコーディングを担当しました。

## 制作期間

2022年6月～7月（約1か月）

## 仮説と目的

私たちは、画像認識の技術を用いるにあたり、「真顔の方がより老人に見えやすいのではないか」という仮説を立てました。

この仮説から、ある顔の画像に対して、「年配か若いのか」と「笑っているか真顔か」の２つを判別するモデルの作成を行い、表情と見た目の年齢に関係があるのかを検証することを目的としてシステムを制作しました。

## 制作コード

### 顔の識別システムのコード

https://colab.research.google.com/drive/1KnujMqJDVc1ohU-93ZIquNffMVmMrt1E

### 顔画像の切り抜きシステムのコード

https://colab.research.google.com/drive/1RqdaAzhVCSYiAFklSZGV0s9x_lnZyT7-

## 使用データ

CelebA(https://mmlab.ie.cuhk.edu.hk/projects/CelebA.html)

有名人の大規模顔画像データセット。

カラー178×218ピクセルの計202,599枚で構成されている。

40種類のラベルがついており、抽出して使用することが出来る。

## 開発体制

### 顔画像の切り抜きシステムと顔判別システムのコーディング
> 新屋拓海
### データセットの加工
> 伊藤生慈・長嶋康太
### 発表資料の準備
> 小田涼平・川上龍仁

## 推しポイント

- データセットの加工

CelebAのラベルを用いて使用したい顔画像の抽出を行い、その後、画像のサイズ調整や間違った画像の削除、データセットの数量の均一化を行いました。

- 精度の高い分類モデルの制作

データセットに合うよう、プログラムの調整を行いました。

## 開発技術
### プログラミング言語
- Python

### 利用したフレームワーク・ライブラリ
- Google Colaboratory
- numpy
- PIL
- cv2
- facenet-pythorch

### その他開発に利用したツール
- Google Presentation
