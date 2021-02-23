# USB 내부 파일 암호화 소프트웨어
### USB 연결을 스스로 인식하여 내부의 파일들을 암호화하는 소프트웨어 (보안목적)

### Author: Tackhyun Jung

### Status: 완료

### 핵심목표
1) device watcher를 통한 단말기에 저장장치 연결 감지 코드 구현 (완료)
2) 비동시식 처리 기반의 실시간 파일 암호화 루틴 구현 (완료)
3) AES 256bit 암호화를 통한 안전한 파일 암호화 구현 (완료)

---

### 사용된 기술
* AES 256bit
* 비동기식 처리
* 파일시스템 감시 코드

---

### Requirement
* C# (.NET FRAMEWORK 3.5 이상)
* System.Collections.Generic;
* System.Net.NetworkInformation;
* System.Runtime.InteropServices;

---

### Usage

```
> Build Project
> Run Project
```

---
