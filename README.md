# HandTrackingGrab
HandTracking  Grab 연구      
개요
--------------------------------------------------------------------------------
초반에 pinch를 이용해서 grab이 되도록, 접근하였습니다.       
pinch로 grab하는 것이 사용자들한테 많이 힘들 것 같아서,  
gesture 방식으로 grab이 되도록 고쳤습니다.        
그랬더니, 이전보다는 더 개선이 되어졌습니다.             
그래서 앞으로 프로젝트에서는          

설명
---------------------------------------------------------------------------------
주먹 gesture를 할 때 grab이 되도록 코드를 작성했습니다.
GrabDestroy할 때 파괴할 오브젝트의 collider 값을 갖고 있는 m_grabCandidates 변수에 
접근하여, 해당 collider를 제거해줌.       
그래서 Grab한 상태에서 물체가 파괴가 되어도 오류가 발생하는 일을 제거함.     
(Grab 상태에서 오브젝트가 파괴되면 발생하는 오류:  OVRGrabber 코드 안에 있는      
ClosestPointOnBounds관련 오류가 발생함)      
그래도 오류가 발생하는 일이 발생하여서,           
Grab을 시작하기 전에,     
m_grabCandidates에서 key값이 null 일 때, 제거해주도록 코드를 작성했습니다.     
그래서 Grab과 관련된 오류가 다 사라졌습니다.          

앞으로 Grab 계획
-----------------------------------------------------------------------------------
전에 사용했던 손동작 지정을 시간적 여유가 된다면 추가할 예정입니다.
