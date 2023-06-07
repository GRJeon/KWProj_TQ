# ⁉️ 스무고개 게임 프로젝트
##### TQ(Twenty Question Game)
##### 광운대학교 2023학년도 1학기 응용소프트웨어실습 과목 팀 프로젝트입니다.
<br>

## 📆 개발 기간
##### 2023년 1학기 `2023-04-13 ~ 2023-06-03`

소켓 프로그래밍을 활용한 채팅 프로그램을 모티브로 `C# (.Net Framework 4.7.2)` Winform 과 `Sqlite` 를 사용했습니다.

UI 디자인은 `MetroFramework` 와 `MetroSetUI`를 사용했습니다.
<br><br>

## 🚀 Contributors

- **전귀로** ([GitHub 링크](https://github.com/GRJeon))
- 박혜주 ([GitHub 링크](https://github.com/daisy0417))
- 배영현 ([GitHub 링크](https://github.com/Youngbae1126))
- 이정원 ([GitHub 링크](https://github.com/won31080))
<br><br>

## ⚠️ 폰트가 제대로 보이지 않을 경우

##### 게임에서 사용된 폰트 파일의 경로

`KWProj_TQ/client/client/Resources/HANCOMMALANGMALANG-BOLD.TTF`
<br><br>

## ⚠️ Sqlite 에러가 발생할 경우

##### 만약 ServerForm을 실행할 때 Sqlite 에러가 발생한다면 다음 단계를 따라 해결할 수 있습니다:
1. Visual Studio를 엽니다.
2. "도구" 메뉴로 이동합니다.
3. "Nuget 패키지 관리자"를 선택합니다.
4. "솔루션용 Nuget 패키지 관리"를 선택합니다.
5. "SQLite"를 찾아 제거합니다.
6. 다시 "SQLite"를 설치합니다.
<br><br>

## 🔧 고정 서버 IP 변경 방법

##### 만약 고정된 서버 IP를 변경하고 싶다면 다음 단계를 따라 할 수 있습니다:

1. "client" 프로젝트를 빌드합니다.
2. `KWProj_TQ/client/client/bin/Debug/MyServerIP.txt` 파일을 엽니다.
3. 원하는 IP를 위에서부터 작성합니다. 기본값은 `127.0.0.1`입니다.
