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

```flow
st=>start: 开始
op1=>operation: 获取分数
op2=>operation: 领取奖励
cond=>condition: 分数大于4000？
op3=>operation: 增加分数
op4=>operation: 新赛季
cond2=>condition: 分数大于4000？
op5=>operation: 计算分数
op6=>operation: 分数不变


e=>end: 结束
st->op1->op2->cond
cond(no)->op3->op1
cond(yes)->op4->cond2
cond2(no)->op6->op1
cond2(yes)->op5->op1
op5->e
```
