using System.Collections.Generic;

public class Headers
{
    public static string SCENE_NAME_LOGO = "Logo";
    public static string SCENE_NAME_Title = "Title";
    public static string SCENE_NAME_LOBBY = "Lobby";

    // 패킷 데이터 => 사용 안함
    public struct UserDataPacketData
    {
        /// <summary>
        /// 아래 열거체는, 해당 행에 등록된 데이터 순서대로, 각 column의 이름을 의미한다.
        /// 즉, 뒤끝 대시보드에서 변수 내용을 바꿨다면, 아래 enum 테이블도 변경 해야함.
        /// </summary>
        public enum SchemaVariables { nickname, coin, credit, cash };

        public string Nickname;
        public int Coin;
        public int Credit;
        public int Cash;
    }
}
