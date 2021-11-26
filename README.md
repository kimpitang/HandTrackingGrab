# HandTrackingGrab
## HandTracking  Grab 연구 개요

초반에 pinch를 이용해서 grab이 되도록 만들었으나,           
pinch로 grab하는 것이 사용자 입장에서는 많이 힘들 것 같아서       
주먹을 쥔 상태에서 grab이 되도록 고쳤습니다.       
                
## 설명

* 물건을 grab한 상테이서 물체를 파괴 시 OVRGrabber 내에 있는 ClosestPointOnBounds 관련 오류와\n 
  MoveGrabbedObject 관련 오류가 발생합니다.          
  --> 해결책: 물건 파괴 시 m_grabCandidates 변수에 접근해서 파괴할 물건의 collider를 제거했습니다.

* 오큘러스 카메라 인식 문제로 카메라가 손에 잡고 있는 물건을 제대로 캡쳐하지 못해서 물건이 손에서 벗어난 오류가 발생했습니다.     
  --> 해결책: 1) 하드웨어적인 문제를 고칠 수 없어, 소프트웨어적으로 최대한 개선을 하는 방식을 선택했습니다.     
              2)  
