# HandTrackingGrab
HandTracking  Grab 연구            
Grab한 물체가 갑자기 파괴하면 collision관련 오류가 발생하여,             
위치를 다른 곳으로 옮겨서 파괴되도록 설정했습니다.         
손동작 지정이 필요한 오브젝트인 경우에(NPC_part, Tool태크를 가진 오브젝트)는          
OVRGrabbable.cs 상속한 코드()로 위치와 회전 값을 지정했고, 
손동작 지정이 필요없는 오브젝트 같은 경우에는 NoPose태크로 지정해주었다.        
