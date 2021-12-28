## 1. 整体框架

​		玩家数据（分数，段位），赛季系统（各个分数对应的奖励，新赛季分数规则，）

## 2. 项目框架

* scene
  * MainScene
* Scripts
  * ChampinAwardItemCtrl    //奖励prefab控制脚本
  * ChampinPanelCtrl             //奖励列表和信息界面控制脚本
  * DataManager                     //玩家数据类----分数/段位/赛季信息
  * MainView                            //全局控制
* Resources
* Prefabs                            //存储prefab

 ## 3. 代码逻辑分层

| 文件夹     | 主要职责                 |
| ---------- | ------------------------ |
| Resources  | 存放资源                 |
| Scripts    | 存放脚本文件             |
| Prefabs    | 存放预制体资源           |
| Scene      | 存放场景文件             |

## 4. 流程图
![](https://github.com/89trillion-wangjian/ChampinRoad/blob/master/seq.png)
