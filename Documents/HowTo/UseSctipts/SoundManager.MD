# SoundManager.csの使用方法

**サウンドマネージャーは効果音, BGMを管理,再生するものです**
分からないことがあったら伊東までお願いします

サウンドマネージャーのパスです

<img src= "https://user-images.githubusercontent.com/89116872/159146777-bfffa271-43d2-45c5-b56e-342e837536bf.png" width="300" align="top">

サウンドを設定する際には上記のプレハブをだれか1人が編集するようにお願いします。

## 効果音の設定方法

<img src="https://user-images.githubusercontent.com/89116872/172868135-41a5851b-fc6a-4d2c-944e-ba9b0973f7be.png" width="650" align="top">赤い枠内に効果音を設定していく形になります。

Name は 効果音の名前を入力して下さい(音を流す際アクセスするキーワードになります)

Prefabは効果音が流れるプレハブを設定します(後述します)

MaxCountについては10ほどで大丈夫です
MaxCountはプールにするプレハブの数になります

## 効果音のプレハブの設定方法

<img src= "https://user-images.githubusercontent.com/89116872/159148376-ea7b8ff6-1144-4c0d-9b09-04e307df4742.png" width="500" align="top">このようにプレハブを作成していく形になります。

1. SoundManagerExampleを複製してください(Ctrlキー + Dキー)

2. 名前を効果音の設定で行った Nameと同じ名前にしてください

3.効果音のオーディオクリップを設定し、下記画像のようにPlayOnAwakeにチェックが入っていることを確認してください
<img src= "https://user-images.githubusercontent.com/89116872/159149118-857fa167-bab5-4eb3-b26c-19ab0d474f07.png" width="200" align="top">

4.PrefabDisablerを付けてください DisableTimeは効果音の長さプラス少し余裕を持たせた時間で設定して下さい
<img src= "https://user-images.githubusercontent.com/89116872/172866345-8ac0a6fb-a11a-41e4-a40a-9f816b4e55a7.png" width="500" align="top">

5. SoundManagerの設定への設定を忘れないようにお願いします

## BGM の設定方法

<img src= "https://user-images.githubusercontent.com/89116872/159148809-7bf2da74-b2bf-498d-8b96-65505da4dbfa.png" width="300" align="top">このプレハブをBGMの流したいシーンに1つ配置する方になります

===設置後===

<img src= "https://user-images.githubusercontent.com/89116872/159148937-6f1c7246-2611-452b-af91-fb28f6f8b46f.png" width="300" align="top">

**設置後に**流したいBGMのオーディクリップと音量を設定して完了です
