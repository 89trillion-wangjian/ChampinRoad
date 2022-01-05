## 1. 整体框架

model中存储玩家数据（分数，段位），并设置委托，controller监听ui事件，并处理加分，新赛季，view中监听委托事件，当信息变化时view中相应刷新

## 2. 项目框架

* Scene
  * MainScene
* Scripts                       #脚本目录
* Res                           #静态资源
* Prefabs                       #存储prefab

 ## 3. 代码逻辑分层
|文件夹        |主要职责                  |
|-----------   |----------              |
|Controller     |处理加分，新赛季分数计算                 |
|Model       |存放玩家数据（分数，赛季等），设置委托            |
|Utils          |事件传递脚本 |
|View         |委托事件绑定，处理分数现实，宝箱的刷新等              |

## 4. 流程图
![](https://github.com/89trillion-wangjian/ChampinRoad/blob/master/seq.png)
