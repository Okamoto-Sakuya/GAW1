# Zombie Survival Game

## 概要

Unityで制作したゾンビサバイバルゲームです。

プレイヤーはゾンビから逃げながら戦い、ラウンドごとに増加するゾンビの群れを倒していきます。

## ゲーム内容

* FPS視点でプレイヤーを操作
* マウスで視点操作
* WASDで移動
* ゾンビがNavMeshを使用してプレイヤーを追跡
* ゾンビを倒してラウンドを進行
* ラウンドが進むほど出現するゾンビ数が増加
* ゾンビに接触するとゲームオーバーシーンへ移動

## 操作方法

| 操作            | 内容      |
| ------------- | ------- |
| W / A / S / D | 移動      |
| マウス           | 視点操作    |
| 左クリック         | 攻撃（実装時） |

## システム

### Player Controller

プレイヤーの基本操作を管理します。

機能:

* 移動
* 視点操作
* ヘッドボブ演出

### Zombie Chase

ゾンビの追跡AIを管理します。

機能:

* NavMeshAgentによる移動
* Playerタグを持つオブジェクトを自動探索
* プレイヤーへの追跡

### Zombie Health

ゾンビの体力を管理します。

機能:

* ダメージ処理
* HPが0になった時の死亡処理
* ラウンド管理への通知

### Round Manager

ラウンド進行を管理します。

機能:

* ラウンド開始
* ゾンビ出現数管理
* 全ゾンビ撃破後の次ラウンド開始
* ラウンドごとの敵数増加

### Zombie Spawner

ゾンビの出現を管理します。

機能:

* 複数スポーン地点から生成
* ラウンドごとのゾンビ生成

## 必要なUnity設定

### NavMesh

ゾンビAIを動作させるため、ステージの床にNavMeshを設定してください。

必要項目:

* NavMesh Surface
* Bake済みのNavMesh
* ZombieにNavMeshAgentを追加

## Tag設定

### Player

プレイヤーオブジェクトには以下のTagを設定してください。

```
Player
```

ゾンビAIはこのTagを検索して追跡します。

## Scene設定

シーン移動を使用する場合、移動先のシーンをBuild Settingsへ追加してください。

例:

```
MainScene
GameOver
Result
```

## Prefab構成

### Player

```
Player
├─ PlayerController
└─ Camera
```

### Zombie

```
Zombie
├─ NavMeshAgent
├─ ZombieChase
├─ ZombieHealth
└─ ZombieAttack
```

## 開発環境

* Unity
* C#
* NavMesh AI System

## 今後の追加予定

* 武器システム
* 弾薬管理
* ゾンビ種類追加
* ボスゾンビ
* UI（HP・ラウンド表示）
* サウンド追加














<img width="1904" height="1068" alt="スクリーンショット 2026-09-04 141918" src="https://github.com/user-attachments/assets/f0b01d71-5033-4a51-a49a-6e164ec2512b" />

