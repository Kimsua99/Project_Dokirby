using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LockPattern : MonoBehaviour
{
    public GameObject linePrefab;
    public Canvas canvas;
    public GameObject LockPanel;

    private Dictionary<int, CircleIdentifier> circles;

    private List<CircleIdentifier> lines;

    public List<int> patternNums;

    private GameObject lineOnEdit;//가장 마지막(라인이 커서 따라 다님)
    private RectTransform lineOnEditRcTs;
    private CircleIdentifier circleOnEdit;

    public RuntimeAnimatorController Line;
    public RuntimeAnimatorController LineFalse;

    List<int> SpringLock = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    List<int> UmbrellaLock = new List<int> { 0, 1, 2, 4, 7 };
    List<int> GrassLock = new List<int> { 6, 3, 0, 4, 2, 5, 8 };
    List<int> ShovelLock = new List<int> { 0, 4, 2 };

    public Sprite originCircle;

    bool isSpringRight;
    bool isUmbrellaRight;
    bool isGrassRight;
    bool isShovelRight;

    public bool unLocking;

    public bool ColorGreen = false;
    public bool ColorRed = false;

    bool enabled = true;

    void Start()
    {
        circles = new Dictionary<int, CircleIdentifier>();
        lines = new List<CircleIdentifier>();
        patternNums = new List<int>();

        for (int i = 0; i < transform.childCount; i++)
        {
            var circle = transform.GetChild(i);

            var identifier = circle.GetComponent<CircleIdentifier>();

            identifier.id = i;

            circles.Add(i, identifier);
        }
    }

    void Update()
    {
        if (unLocking)
        {
            //Vector3 mousePos = LockPanel.transform.TransformPoint(Input.mousePosition);
            //lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x, Vector3.Distance(mousePos, circleOnEdit.transform.localPosition));
            //lineOnEditRcTs.rotation = Quaternion.FromToRotation(Vector3.up, (mousePos - circleOnEdit.transform.localPosition).normalized);
        }
    }

    IEnumerator Release()
    {
        enabled = false;

        yield return new WaitForSeconds(2);

        foreach (var circle in circles)
        {
            //circle.Value.GetComponent<UnityEngine.UI.Image>().color = Color.white;
            circle.Value.GetComponent<UnityEngine.UI.Image>().sprite = originCircle;
            circle.Value.GetComponent<Animator>().enabled = false;
        }

        foreach (var line in lines)//마우스 떼면 라인 다 없애줌. 
        {
            Destroy(line.gameObject);
        }

        lines.Clear();
        patternNums.Clear();

        lineOnEdit = null;
        lineOnEditRcTs = null;
        circleOnEdit = null;

        enabled = true;

        isSpringRight = false;
        isUmbrellaRight = false;
        isGrassRight = false;
        isShovelRight = false;

        ColorGreen = false;
        ColorRed = false;

    }
    GameObject CreateLine(Vector3 pos, int id)
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("Brush");

        if (GameObject.FindObjectOfType<SoundManager>().GetComponent<SoundManager>().isBrush1 == true)
        {
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("Brush1");
        }
        if (GameObject.FindObjectOfType<SoundManager>().GetComponent<SoundManager>().isBrush2 == true)
        {
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("Brush2");
        }
      

        var line = GameObject.Instantiate(linePrefab, LockPanel.transform);

        line.transform.localPosition = pos;

        var lineIdf = line.AddComponent<CircleIdentifier>();


        lineIdf.id = id;

        patternNums.Add(id);

        lines.Add(lineIdf);
        return line;
    }

    void TrySetLineEdit(CircleIdentifier circle)//이미 선택한 원 다시 클릭한 경우 아이디가 같아서 라인 생성이 안되게 함.
    {
        //Debug.Log(circle.id);
        foreach (var line in lines)
        {
            if (line.id == circle.id)
            {
                return;
            }
        }

        lineOnEdit = CreateLine(circle.transform.localPosition, circle.id);
        lineOnEditRcTs = lineOnEdit.GetComponent<RectTransform>();
        circleOnEdit = circle;
    }

    void EnableColorFade(Animator anim)
    {
        anim.enabled = true;
        anim.runtimeAnimatorController = Line;
        anim.Rebind();
    }
    void EnableColorRed(Animator anim)
    {
        anim.enabled = true;
        anim.runtimeAnimatorController = LineFalse;
        anim.Rebind();
    }

    public void OnMouseEnterCircle(CircleIdentifier idf)
    {
        if (enabled == false)
        {
            return;
        }
        if (unLocking)
        {
            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x, Vector3.Distance(circleOnEdit.transform.localPosition, idf.transform.localPosition));
            lineOnEditRcTs.rotation = Quaternion.FromToRotation(
                Vector3.up,
                (idf.transform.localPosition - circleOnEdit.transform.localPosition).normalized);

            TrySetLineEdit(idf);
        }
    }

    public void OnMouseExitCircle(CircleIdentifier idf)
    {
        if (enabled == false)
        {
            return;
        }
    }

    public void OnMouseDownCircle(CircleIdentifier idf)
    {
        if (enabled == false)
        {
            return;
        }
        unLocking = true;

        TrySetLineEdit(idf);
    }

    public void ComparePattern()
    {
        isSpringRight = SpringLock.SequenceEqual(patternNums);
        if (isSpringRight == true && (isUmbrellaRight == false || isGrassRight == false || isShovelRight == false))
        {
            ColorGreen = true;
            FindObjectOfType<CharacterChange>().GetComponent<CharacterChange>().GetPattern("spring");
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("Change");
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("None");
        }


        isUmbrellaRight = UmbrellaLock.SequenceEqual(patternNums);
        if (isUmbrellaRight == true && (isSpringRight == false || isGrassRight == false || isShovelRight == false))
        {
            ColorGreen = true;
            FindObjectOfType<CharacterChange>().GetComponent<CharacterChange>().GetPattern("Umbrella");
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("Change");
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playTyping("None");
        }


        isGrassRight = GrassLock.SequenceEqual(patternNums);
        if (isGrassRight == true && (isSpringRight == false || isUmbrellaRight == false || isShovelRight == false))
        {
            ColorGreen = true;
            FindObjectOfType<CharacterChange>().GetComponent<CharacterChange>().GetPattern("Grass");
        }


        isShovelRight = ShovelLock.SequenceEqual(patternNums);
        if (isShovelRight == true && (isSpringRight == false || isGrassRight == false || isUmbrellaRight == false))
        {
            ColorGreen = true;
            FindObjectOfType<CharacterChange>().GetComponent<CharacterChange>().GetPattern("Shovel");
        }
        if (isSpringRight == false && isUmbrellaRight == false && isGrassRight == false && isShovelRight == false)
        {
            ColorRed = true;
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("ChangeX");

        }
        
    }

    public void OnMouseUpCircle(CircleIdentifier idf)
    {
        ComparePattern();

        if (enabled == false)
        {
            return;
        }
        if (unLocking)
        {
            if (ColorGreen == true)
            {
                foreach (var line in lines)
                {
                    EnableColorFade(circles[line.id].gameObject.GetComponent<Animator>());
                }

                Destroy(lines[lines.Count - 1].gameObject);
                lines.RemoveAt(lines.Count - 1);

                foreach (var line in lines)
                {
                    EnableColorFade(line.GetComponent<Animator>());
                }
                StartCoroutine(Release());
            }

            if (ColorRed == true)
            {
                foreach (var line in lines)
                {
                    EnableColorRed(circles[line.id].gameObject.GetComponent<Animator>());
                }

                Destroy(lines[lines.Count - 1].gameObject);
                lines.RemoveAt(lines.Count - 1);

                foreach (var line in lines)
                {
                    EnableColorRed(line.GetComponent<Animator>());
                }
                StartCoroutine(Release());
            }
        }
        unLocking = false;
    }
}
