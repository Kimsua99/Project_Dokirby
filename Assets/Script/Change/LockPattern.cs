using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPattern : MonoBehaviour
{
    public GameObject linePrefab;
    public Canvas canvas;
    public GameObject LockPanel;

    private Dictionary<int, CircleIdentifier> circles;

    private List<CircleIdentifier> lines;

    private GameObject lineOnEdit;//가장 마지막(라인이 커서 따라 다님)
    private RectTransform lineOnEditRcTs;
    private CircleIdentifier circleOnEdit;

    public bool unLocking;

    bool enabled = true;
    void Start()
    {
        circles = new Dictionary<int, CircleIdentifier>();
        lines = new List<CircleIdentifier>();

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
            Vector3 mousePos = LockPanel.transform.InverseTransformPoint(Input.mousePosition);

            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x, Vector3.Distance(mousePos, circleOnEdit.transform.localPosition));

            lineOnEditRcTs.rotation = Quaternion.FromToRotation(
                Vector3.up,
                (mousePos - circleOnEdit.transform.localPosition).normalized);
        }
    }

    IEnumerator Release()
    {
        enabled = false;

        yield return new WaitForSeconds(3);

        foreach (var circle in circles)
        {
            circle.Value.GetComponent<UnityEngine.UI.Image>().color = Color.white;
            circle.Value.GetComponent<Animator>().enabled = false;
        }

        foreach (var line in lines)//마우스 떼면 라인 다 없애줌. 
        {
            Destroy(line.gameObject);
        }

        lines.Clear();

        lineOnEdit = null;
        lineOnEditRcTs = null;
        circleOnEdit = null;

        enabled = true;
        
    }
    GameObject CreateLine(Vector3 pos, int id)
    {
        var line = GameObject.Instantiate(linePrefab, LockPanel.transform);

        line.transform.localPosition = pos;

        var lineIdf = line.AddComponent<CircleIdentifier>();


        lineIdf.id = id;

        lines.Add(lineIdf);

        return line;
    }

    void TrySetLineEdit(CircleIdentifier circle)//이미 선택한 원 다시 클릭한 경우 아이디가 같아서 라인 생성이 안되게 함.
    {
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
        //Debug.Log(idf.id);
    }

    public void OnMouseDownCircle(CircleIdentifier idf)
    {
        if (enabled == false)
        {
            return;
        }
        //Debug.Log(idf.id);
        unLocking = true;

        TrySetLineEdit(idf);
    }

    public void OnMouseUpCircle(CircleIdentifier idf)
    {
        if (enabled == false)
        {
            return;
        }
        if (unLocking)
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
        unLocking = false;
    }


}
