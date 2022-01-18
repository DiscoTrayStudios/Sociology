using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourcesScript : MonoBehaviour
{
    // Start is called before the first frame update
    private string[] sources;
    void Start()
    {
        sources = new string[] {
            "More Exclusionary Discipline for Black Girls\n\nBlake, Jamilia J., et al. 'Unmasking the inequitable discipline experiences of urban Black girls: Implications for urban educational stakeholders.' The Urban Review 43.1 (2011): 90-106.",
            "More Exclusionary Discipline for Black Girls\n\nMorris, Edward W. '�Ladies� or �loudies�? Perceptions and experiences of Black girls in classrooms.' Youth & Society 38.4 (2007): 490-515.",
            "Gifted and Talented Education in Relation to Black Girls\n\nCokley, Raven K., and Loni Crumb. '# BlackGirlMagic: The (Mis) education of Gifted Black Girls from Economically Disadvantaged, Rural Communities.' African American Rural Education. Emerald Publishing Limited, 2020."
        };
    }

    // Update is called once per frame
    void Update()
    {

    }


    public string getSource(int index)
    {
        return sources[index];
    }

    public int getSourceLength()
    {
        return sources.Length;
    }
}