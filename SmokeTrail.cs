using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeTrail : MonoBehaviour {

  LineRenderer line;
  Transform tr;
  Vector3[] positions;
  Vector3[] directions;
  int i;
  float timeSinceUpdate = .0f;
  Material lineMaterial;
  float lineSegment = .0f;
  int currentNumerOfPoints = 2;
  bool allPointsAdded = false;
  int numberOfPoints = 10;
  float updateSpeed = .25f;
  float riseSpeed = .25f;
  float spread = .2f;

  Vector3 tempVec;

  void Start () {
    tr = transform;
    line = GetComponent<LineRenderer>();
    lineMaterial = line.material;

    lineSegment = 1f / numberOfPoints;

    positions = new Vector3[numberOfPoints];
    directions = new Vector3[numberOfPoints];

    line.positionCount = currentNumerOfPoints;

    for(i = 0; i < currentNumerOfPoints; i++)
    {
      tempVec = GetSmokeVec();
      directions[i] = tempVec;
      positions[i] = tr.position;
      line.SetPosition(i, positions[i]);
    }
	}
	
	void Update () {
    timeSinceUpdate += Time.deltaTime;

    if(timeSinceUpdate > updateSpeed)
    {
      timeSinceUpdate -= updateSpeed;

      if (!allPointsAdded)
      {
        currentNumerOfPoints++;
        line.positionCount = currentNumerOfPoints;
        tempVec = GetSmokeVec();
        directions[0] = tempVec;
        positions[0] = tr.position;
        line.SetPosition(0, positions[0]);
      }

      if (!allPointsAdded && (currentNumerOfPoints == numberOfPoints))
        allPointsAdded = true;

      for(i = currentNumerOfPoints - 1; i > 0; i--)
      {
        tempVec = positions[i - 1];
        positions[i] = tempVec;
        tempVec = directions[i - 1];
        directions[i] = tempVec;
      }
      tempVec = GetSmokeVec();
      directions[0] = tempVec;
    }

    for (i = 1; i < currentNumerOfPoints; i++)
    {
      tempVec = positions[i];
      tempVec += directions[i] * Time.deltaTime;
      positions[i] = tempVec;

      line.SetPosition(i, positions[i]);
    }
    positions[0] = tr.position;
    line.SetPosition(0, tr.position);

    if (allPointsAdded)
    {
      lineMaterial.mainTextureOffset = new Vector2(lineSegment * (timeSinceUpdate / updateSpeed), lineMaterial.mainTextureOffset.y);
    }
	}

  Vector3 GetSmokeVec()
  {
    Vector3 smokeVec;

    smokeVec.x = Random.Range(-1f, 1f);
    smokeVec.y = Random.Range(0f, 1f);
    smokeVec.z = Random.Range(-1f, 1f);
    smokeVec.Normalize();
    smokeVec *= spread;
    smokeVec.y += riseSpeed;

    return smokeVec;
  }
}
