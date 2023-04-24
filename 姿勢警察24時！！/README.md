# 姿勢警察24時!!<br>（チーム制作：Azure KinectとUnityを用いた姿勢改善システム）

<img src="https://user-images.githubusercontent.com/106252369/234006576-74979031-dfbb-4498-88bd-13bbfbc994d1.png" width="500px">

## 目次

1.[システム説明](https://github.com/TakumiShinya/Portfolio/blob/main/%E3%82%AB%E3%83%9F%E3%82%B5%E3%83%9E%E3%82%A4%E3%83%B3%E3%82%BF%E3%83%BC%E3%83%B3/README.md#%E3%82%B2%E3%83%BC%E3%83%A0%E8%AA%AC%E6%98%8E)

2.[制作期間](https://github.com/TakumiShinya/Portfolio/blob/main/%E3%82%AB%E3%83%9F%E3%82%B5%E3%83%9E%E3%82%A4%E3%83%B3%E3%82%BF%E3%83%BC%E3%83%B3/README.md#%E5%88%B6%E4%BD%9C%E6%9C%9F%E9%96%93)

3.[システム概要](https://github.com/TakumiShinya/Portfolio/blob/main/%E3%82%AB%E3%83%9F%E3%82%B5%E3%83%9E%E3%82%A4%E3%83%B3%E3%82%BF%E3%83%BC%E3%83%B3/README.md#%E3%82%B2%E3%83%BC%E3%83%A0%E6%A6%82%E8%A6%81)

4.[デモ動画](https://github.com/TakumiShinya/Portfolio/blob/main/%E3%82%AB%E3%83%9F%E3%82%B5%E3%83%9E%E3%82%A4%E3%83%B3%E3%82%BF%E3%83%BC%E3%83%B3/README.md#%E3%83%87%E3%83%A2%E5%8B%95%E7%94%BB)

5.[使用方法](https://github.com/TakumiShinya/Portfolio/blob/main/%E3%82%AB%E3%83%9F%E3%82%B5%E3%83%9E%E3%82%A4%E3%83%B3%E3%82%BF%E3%83%BC%E3%83%B3/README.md#%E9%81%8A%E3%81%B3%E6%96%B9)

6.[開発体制](https://github.com/TakumiShinya/Portfolio/blob/main/%E3%82%AB%E3%83%9F%E3%82%B5%E3%83%9E%E3%82%A4%E3%83%B3%E3%82%BF%E3%83%BC%E3%83%B3/README.md#%E9%96%8B%E7%99%BA%E4%BD%93%E5%88%B6)

7.[意識したこと](https://github.com/TakumiShinya/Portfolio/blob/main/%E3%82%AB%E3%83%9F%E3%82%B5%E3%83%9E%E3%82%A4%E3%83%B3%E3%82%BF%E3%83%BC%E3%83%B3/README.md#%E6%84%8F%E8%AD%98%E3%81%97%E3%81%9F%E3%81%93%E3%81%A8)

8.[推しポイント](https://github.com/TakumiShinya/Portfolio/blob/main/%E3%82%AB%E3%83%9F%E3%82%B5%E3%83%9E%E3%82%A4%E3%83%B3%E3%82%BF%E3%83%BC%E3%83%B3/README.md#%E6%8E%A8%E3%81%97%E3%83%9D%E3%82%A4%E3%83%B3%E3%83%88)

9.[開発技術](https://github.com/TakumiShinya/Portfolio/blob/main/%E3%82%AB%E3%83%9F%E3%82%B5%E3%83%9E%E3%82%A4%E3%83%B3%E3%82%BF%E3%83%BC%E3%83%B3/README.md#%E9%96%8B%E7%99%BA%E6%8A%80%E8%A1%93)

## ゲーム説明
2022年12月～2023年1月に大学の授業である「インタラクティブシステム」にて制作したアプリです。

3人のチームで制作を行い、UnityとAzure Kinectを用いた姿勢改善システムを考案しました。

制作の中で私は、Azure Kinectのセットアップと姿勢取得システムの開発を担当しました。
## 制作期間

2022年12月～2023年1月（約１か月）

## システム概要
【システムのタイトル】姿勢警察24時!!

【対象機器】PC（グラフィックボードが搭載されているもの）

【対象ユーザー】デスクワークや日々の生活で姿勢が悪化している方

### コンセプト
- Azure KinectとUnityを用いたリアルタイム姿勢改善システム

## スクリーンショット

<img src="https://user-images.githubusercontent.com/106252369/234008605-fd044c6f-338e-4222-81ac-33f7e592f897.png" width="500px">

<img src="https://user-images.githubusercontent.com/106252369/234008677-226ae676-b73e-4039-b144-2254fe9e71cb.png" width="500px">

<img src="https://user-images.githubusercontent.com/106252369/234008185-7487159f-1a13-45b1-a574-0e8b28059978.png" width="500px">

## デモ動画

[![姿勢警察24時!!デモ動画](https://user-images.githubusercontent.com/106252369/234004625-2154ddf7-2b7f-414c-a0ef-e966f47c54da.png)](https://youtu.be/cWelwdEfmGo)

https://youtu.be/cWelwdEfmGo

## 目的

本アプリは、Azure Kinect DKとUnityを利用して制作した、Kinectから取得した姿勢データとそこから
算出したスコアを画面に表示することによる、姿勢改善を促進することを目的に作られたアプリです。

## 使用方法

Azure Kinect DKを接続した状態でアプリを起動し、タイトルから「密着開始」ボタンを押して開始します。

その後、姿勢をAzure Kinect DKを通して取得し、その姿勢に応じたスコアが算出・表示されます。

姿勢が悪くなった場合は、画面全体が赤くなり、サイレンの音によって警告されます。また、いい姿勢の場合は「いい姿勢です。」という文字が表示されます。

また、画面内の「一時停止」ボタンを押すと、アプリが一時停止し、同時に現在のスコアとスコアに応じた階級（椎間板ヘルニア級～宝塚級までの全6段階）
が表示されます。

一時停止画面からは、元の姿勢取得画面に戻るほか、そのままアプリを終了することもできます。

### 操作方法

マウスクリック：ボタンを押す

## 開発体制

アルゴリズムの考案・姿勢評価ロゴ制作：東未来翔

プラグインの整理・タイトルロゴの制作：鈴木瑞帆

Azure Kinectのセットアップ・姿勢取得システムの開発：新屋拓海

発表資料（スライド・デモ動画）の制作：東未来翔・鈴木瑞帆・新屋拓海

## 意識したこと

- 自身の動きに応じてアプリ内の挙動がリアルタイムで変化するような（インタラクティブな）システムになるようにした。
- 姿勢をわかりやすく表示するためにシンプルな3Dモデルを使用した。

## 推しポイント

- 座った姿勢を高い精度で取得できる。
- 3Dモデルに自身の姿勢を反映することで姿勢を客観視できる。
- 姿勢の良し悪しを画面の色やスコアによって表示することで、わかりやすくした。

## 開発技術
### プログラミング言語
C#

### 利用したフレームワーク・ライブラリ
Unity / Azure Kineck SDK / Azure Kinect Body Tracking SDK

### その他開発に使用したツール・サービス
Discord / Canva / Google presentation / Google jamboard

