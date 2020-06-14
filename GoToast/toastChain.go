package main

import (
	"log"

	"gopkg.in/toast.v1"
)

// Toast表示のサンプル
// go get gopkg.in/toast.v1 でインストールしておく
func main() {
	notification := toast.Notification{
		AppID:   "ToastSample",
		Title:   "ToastSample",
		Message: "Please click below button",
		Icon:    "C:\\Develop\\csharp\\WPFToastSample\\Release\\sample.ico",
		Actions: []toast.Action{
			{"protocol", "execute popup app", "toastsample:"},
		},
	}
	err := notification.Push()
	if err != nil {
		log.Fatalln(err)
	}
}
