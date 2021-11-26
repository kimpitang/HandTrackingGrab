# HandTrackingGrab
## HandTracking  Grab 연구 개요

초반에 pinch를 이용해서 grab이 되도록 만들었으나,           
pinch로 grab하는 것이 사용자 입장에서는 많이 힘들 것 같아서       
주먹을 쥔 상태에서 grab이 되도록 고쳤습니다.       
                
## 주요 기능 설명

* GrabLeft, GrabRight는 handtracking 상태에서 grab이 가능하도록 만든 코드입니다.

* GrabDetector는 플레이어의 손을 인식하는 기능을 서술한 코드입니다.

* LocationRest는 grab이 가능한 물건이 땅으로 떨어졌을 때 다시 처음 위치로 옮겨주는 기능을 서술한 코드입니다.

* Part 과 Point 관련 코드는 deco 씬에서 grab 할 때 사용하는 코드입니다. 

* Rope은 기본 골격은 참조했지만 Rope에서 사용하는 grab은 여기서 개발한 grab을 사용합니다.

* Tumor는 colon 씬에서 종양 제거할 때 사용하는 코드입니다. (grab이 감지 되면 중력의 영향을 받습니다.) 

* Stent는 heart 씬에서 스텐트를 잡을 때 사용하는 코드입니다.

* TutorialGrabCheck은 사용자가 grab을 했는 지 체크하는 코드이며,    
  사용자 grab을 한 번 이상하게 되면 grab을 당한 물건을 제거해주는 기능도 제공합니다.     

* TutorialThrowCheck은 사용자가 throw을 했는 지 체크하는 코드이며, 
  target에 물건을 던지면 target과 던진 물건을 제거해주는 기능도 제공합니다.    

* ThrowGrabbable은 던지기 기능을 제공하는 코드입니다.

* GrabHandShape 폴더는 물건을 잡을 때 손동작을 지정해주는 코드를 모은 폴더입니다.   
  -> 프로젝트 개발 중간에 넣었으나, 중간에 뺐습니다. 그러나 다시 한 번 더 이 기능을 넣으려고 했으나, 
    개발기간 내에 넣지 못했습니다. 
  -> 나중에 시간이 된다면 해당 기능을 넣어보겠습니다.

## Grab 연구 시 어려운 점

* 물건을 grab하고 나서 다시 물건을 잡을 때 손과 물건이 통과하는 현상이 발생했습니다.    
  --> 해결책: SetPlayerIgnoreCollision 함수 이용 (해당 코드: GrabLeft.cs, GrabRight.cs - GrabFinish 함수)

* 물건을 grab한 상테이서 물체를 파괴 시 OVRGrabber 내에 있는 ClosestPointOnBounds 관련 오류와       
  MoveGrabbedObject 관련 오류가 발생합니다.          
  --> 해결책: 물건 파괴 시 m_grabCandidates 변수에 접근해서 파괴할 물건의 collider를 제거했습니다.
              (해당 코드: GrabLeft.cs, GrabRight.cs - RemoveCandidates 함수 / PartDestroy.cs / TutorialGrabCheck / TutorialThrowCheck.cs / Rope.cs)

* 오큘러스 카메라 인식 문제로 카메라가 손에 잡고 있는 물건을 제대로 캡쳐하지 못해서    
  물건이 손에서 벗어난 오류가 발생했습니다.     
  --> 해결책        
        1) 하드웨어적인 문제를 고칠 수 없어, 소프트웨어적으로 최대한 개선을 하는 방식을 선택했습니다.     
        2) 카메라가 인식문제로 물건이 손에서 벗어나면 물건의 rigidbody 상태를 grab하기 전 상태로 바꾸었습니다.       
                 (해당 코드: adjustGrabbable)
* 물건의 rigidbody가 isKinematic이 true일 때 다시 물건을 잡게 되면 grab이 되지 않는 현상이 발생했습니다.
  --> 해결책 : 물건을 다시 잡으려고 할 때 m_grabCandidates 변수에 접근해서 잡으려고 물체의 collider를 추가했습니다.   
                  (해당 코드: GrabLeft.cs, GrabRight.cs - AddCandidates 함수 / Bronchial.cs, Stent,cs - update 함수 일부분)
         
* Grab 시 잡힌 물건마다 위치를 지정하는 부분이 어려웠습니다. 그래서 물건마다 tag를 지정하였고, 
  지정한 tag의 물건을 잡을 때 해당 물건에 맞는 손동작을 지정하였고 물건의 위치를 지정했습니다. 

* 물건을 잡고 던질 때 자연스러운 던지기 잘 되지 않아서 이 부분을 개선하고자 했습니다. 
  그래서 물건의 회전벡터와 거리벡터의 외적값으로 보정하였고 물건이 OVRGrabbable보다 잘 던지게 되었습니다.      

