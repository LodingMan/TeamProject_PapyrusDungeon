# 3 / 25 ~ 3 / 26 Hero 클래스 구조 수정사항 -> 송하늘

히어로 스킬 추가, 
이름 랜덤테이블 추가,
저장된 히어로 데이터 로드 후 오브젝트 생성, 
히어로 오브젝트 생성시 랜덤으로 이름부여, 
SkillTable데이터 최적화, 
StatScript의 맴버변수 Stat클래스 하나로 통합


# 3/ 26 스킬 시스템 구현 - 윤성근
UI -> SkillFunc_ysg.cs
변경할 내용: 같은 태그 중복처리

# 3/26 ItemClass 추가 / GuildUI작업 시작 -> 송하늘
관리는 SkillTable, EquipTable과 동일한 형태의 ItemTable.cs를 생성했음. 
접근법도 다른 Table과 동일한 방법으로 가능. 