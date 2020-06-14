# wpf toast sample

---
## 実行までの流れ

- Releaseフォルダのregister.regを起動したいexeのパスに書き換える

```reg
[HKEY_CLASSES_ROOT\toastsample\shell\open\command]
**@="C:\\Develop\\csharp\\WPFToastSample\\Release\\popupApp.exe"**
```

- register.reg をダブルクリックしてレジストリーキーを登録

- PushApp.slnをReleaseビルド

- GoToastフォルダで go build
    - 生成されたexeをReleaseフォルダに移動

- ReleaseフォルダのpushApp.exeを実行

- テキストボックスにGoToast.exeを入力して**PushToast**を実行

- トーストが表示されるので**execute popup app**を押下

- popupAppが実行される


## 背景

wpfでトーストを使おうとするとDesktopBridgeを使うことになってしまう。

**wpfのままで**トースト通知できる方法を探した結果、別アプリでトースト通知する方法に行きつきました。


---

### Toast 参考

https://github.com/go-toast/toast

### 現状の問題点

- golang側でnotification.Push()が失敗したときの処理が甘い
    - MessageBox.Show()でエラーを出す。Iconのパスをクリアにして実行させるなど

