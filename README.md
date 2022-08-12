# Any project name

> 企画書 AnyURL

> 仕様書 AnyURL

## 注意点
- productionブランチは各プロジェクトで作ること

## 開発環境

| エンジン | バージョン  |
| ---------- | ----------- |
| Unity      | 2020.3.23f1 |

## 導入済みアセット

### DOTween Pro
> https://assetstore.unity.com/packages/tools/visual-scripting/dotween-pro-32416

### UniRx
> https://assetstore.unity.com/packages/tools/integration/unirx-reactive-extensions-for-unity-17276

### UniTask
> https://github.com/Cysharp/UniTask

### NaughtyAttributes
> https://github.com/dbrizov/NaughtyAttributes

## コード規則

変数名は[キャメルケース](https://e-words.jp/w/%E3%82%AD%E3%83%A3%E3%83%A1%E3%83%AB%E3%82%B1%E3%83%BC%E3%82%B9.html) (先頭小文字)

メンバー変数の接頭辞には「＿」(アンダースコア)を付けること

関数名　クラス名　プロパティの名前は[パスカルケース](https://wa3.i-3-i.info/word13955.html) (先頭大文字)  

### ブランチ名

ブランチの名前は[スネークケース](https://e-words.jp/w/%E3%82%B9%E3%83%8D%E3%83%BC%E3%82%AF%E3%82%B1%E3%83%BC%E3%82%B9.html#:~:text=%E3%82%B9%E3%83%8D%E3%83%BC%E3%82%AF%E3%82%B1%E3%83%BC%E3%82%B9%E3%81%A8%E3%81%AF%E3%80%81%E3%83%97%E3%83%AD%E3%82%B0%E3%83%A9%E3%83%9F%E3%83%B3%E3%82%B0,%E3%81%AA%E8%A1%A8%E8%A8%98%E3%81%8C%E3%81%93%E3%82%8C%E3%81%AB%E5%BD%93%E3%81%9F%E3%82%8B%E3%80%82)
(すべて小文字単語間は「＿」(アンダースコア))
- 機能を作成するブランチであれば接頭辞に「feature/」
- 機能の修正等は接頭辞に「fix/」
- 削除を行う際は接頭辞に「remove/」

### boolean メソッド命名規則

> https://qiita.com/GinGinDako/items/6e8b696c4734b8e92d2b

### region 規則

```shell

public class <ANY NAME>:...
{
    #region Properties
        // プロパティを入れる。
    #region Inspector Variables
        // unity inpectorに表示したいものを記述。
    #region Member Variables
        // プライベートなメンバー変数。
    #region Constant
        // 定数をいれる。
    #region Events
        //  System.Action, System.Func などのデリゲートやコールバック関数をいれるところ。
    #region Unity Methods
        //  Start, UpdateなどのUnityのイベント関数。
    #region Enums
        // 列挙型を入れる。
    #region Public Methods
        //　自身で作成したPublicな関数を入れる。
    #region Private Methods
        // 自身で作成したPrivateな関数を入れる。
}
```
