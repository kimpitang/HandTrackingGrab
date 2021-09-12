# HandTrackingGrab2
pinchGrab1보다 더 발전된 버전입니다.                        
프레임이 버벅버벅 거리는 것을 해결하였습니다.       
물체가 Grab 후에 손이 Grab했던 물체에 통과하는 문제가 발생하였습니다.          
그래서, SetPlayerIgnoreCollision함수를 사용하여, 통과하는 문제를 해결했습니다.           
