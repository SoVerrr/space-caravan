using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RouteFixer : MonoBehaviour
{
    public GameObject deadEnd, routeStraight, threeWay, fourWay, corner;

    public void FixRouteAtPosition(Placement placement, Vector3Int temporaryPosition)
    {
        // it will check in this order [right, up, left, down] = [0, 1, 2, 3]
        var result = placement.getNeighbourtStatus(temporaryPosition);
        int roadCount = 0;

        roadCount = result.Where(x => x == GridStatus.Route).Count(); // Count instances of Routes in array

        if(roadCount == 0 || roadCount == 1)
        {
            CreateDeadEnd(placement, result, temporaryPosition);
        } else if(roadCount == 2)
        {
            if (CreateStraightRoute(placement, result, temporaryPosition))
                return;
            CreateCorner(placement, result, temporaryPosition);
        } else if(roadCount == 3)
        {
            Create3Way(placement, result, temporaryPosition);
        } else
        {
            Create4Way(placement, result, temporaryPosition);
        }


        
    }

    private void Create4Way(Placement placement, GridStatus[] result, Vector3Int temporaryPosition)
    {
        placement.ModifyStructureModel(temporaryPosition, fourWay, Quaternion.identity);
    }

    // Result = [Left, up, right, down]
    private void Create3Way(Placement placement, GridStatus[] result, Vector3Int temporaryPosition)
    {
        if (result[1] == GridStatus.Route && result[2] == GridStatus.Route && result[3] == GridStatus.Route) // reverse T-turn 
        {
            placement.ModifyStructureModel(temporaryPosition, threeWay, Quaternion.Euler(0, 180, 0));
        }
        else if (result[2] == GridStatus.Route && result[3] == GridStatus.Route && result[0] == GridStatus.Route) // T-turn 
        {
            placement.ModifyStructureModel(temporaryPosition, threeWay, Quaternion.Euler(0, 270, 0));
        }
        else if (result[3] == GridStatus.Route && result[0] == GridStatus.Route && result[1] == GridStatus.Route) // T-turn connecting from the down, left, up
        {
            placement.ModifyStructureModel(temporaryPosition, threeWay, Quaternion.identity);
        }
        else if (result[0] == GridStatus.Route && result[1] == GridStatus.Route && result[2] == GridStatus.Route) // T-turn connecting from the left, up, right
        {
            placement.ModifyStructureModel(temporaryPosition, threeWay, Quaternion.Euler(0, 90, 0));
        }
    }

    private void CreateCorner(Placement placement, GridStatus[] result, Vector3Int temporaryPosition)
    {
        if (result[1] == GridStatus.Route && result[2] == GridStatus.Route) 
        { 
            placement.ModifyStructureModel(temporaryPosition, corner, Quaternion.Euler(0, 90, 0));
        }
        else if (result[2] == GridStatus.Route && result[3] == GridStatus.Route) 
        {
            placement.ModifyStructureModel(temporaryPosition, corner, Quaternion.Euler(0, 180, 0));
        }
        else if (result[3] == GridStatus.Route && result[0] == GridStatus.Route) 
        {
            placement.ModifyStructureModel(temporaryPosition, corner, Quaternion.Euler(0, 270, 0));
        }
        else if (result[0] == GridStatus.Route && result[1] == GridStatus.Route) 
        {
            placement.ModifyStructureModel(temporaryPosition, corner, Quaternion.Euler(0, 0, 0));
        }
    }

    private bool CreateStraightRoute(Placement placement, GridStatus[] result, Vector3Int temporaryPosition)
    {
        if (result[0] == GridStatus.Route && result[2] == GridStatus.Route)
        {
            placement.ModifyStructureModel(temporaryPosition, routeStraight, Quaternion.identity);
            return true;
        } else if (result[1] == GridStatus.Route && result[3] == GridStatus.Route)
        {
            placement.ModifyStructureModel(temporaryPosition, routeStraight, Quaternion.Euler(0, 90, 0));
            return true;
        }
        return false;
    }

    private void CreateDeadEnd(Placement placement, GridStatus[] result, Vector3Int temporaryPosition)
    {
        if (result[1] == GridStatus.Route) 
        {
            placement.ModifyStructureModel(temporaryPosition, deadEnd, Quaternion.Euler(0, 90, 0));
        }
        else if (result[2] == GridStatus.Route ) 
        {
            placement.ModifyStructureModel(temporaryPosition, deadEnd, Quaternion.Euler(0, 180, 0));
        }
        else if (result[3] == GridStatus.Route ) 
        {
            placement.ModifyStructureModel(temporaryPosition, deadEnd, Quaternion.Euler(0, 270, 0));
        }
        else if (result[0] == GridStatus.Route) 
        {
            placement.ModifyStructureModel(temporaryPosition, deadEnd, Quaternion.Euler(0, 0, 0));
        }
    }
}
