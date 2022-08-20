using System.Collections.Generic;

public class Headers
{
    public static string SCENE_NAME_LOGO = "Logo";
    public static string SCENE_NAME_Title = "Title";
    public static string SCENE_NAME_LOBBY = "Lobby";

    // ��Ŷ ������ => ��� ����
    public struct UserDataPacketData
    {
        /// <summary>
        /// �Ʒ� ����ü��, �ش� �࿡ ��ϵ� ������ �������, �� column�� �̸��� �ǹ��Ѵ�.
        /// ��, �ڳ� ��ú��忡�� ���� ������ �ٲ�ٸ�, �Ʒ� enum ���̺� ���� �ؾ���.
        /// </summary>
        public enum SchemaVariables { nickname, coin, credit, cash };

        public string Nickname;
        public int Coin;
        public int Credit;
        public int Cash;
    }
}
