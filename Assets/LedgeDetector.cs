using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LedgeDetector : MonoBehaviour
{
    public TouchSensor[] Sensors;
    // Use this for initialization
    void Start()
    {
        Sensors = Sensors.OrderBy(x => x.transform.rotation.eulerAngles.y).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            GetHangingOrientation();

        }

    }


    public HangingResult GetHangingOrientation()
    {
        List<TouchSensor> biggestUntriggeredGapSensors = new List<TouchSensor>();
        List<TouchSensor> untriggeredGapSensors = new List<TouchSensor>();

        bool isDone = false;
        bool isLooped = false;
        for (int i = 0; i < Sensors.Length && !isDone; i++)
        {
            var sensor = Sensors[i];
            sensor.Test();
            if (!sensor.IsTriggered && untriggeredGapSensors.Count < 22)
            {
                untriggeredGapSensors.Add(sensor);
                if (i == Sensors.Length - 1)
                {
                    i = -1;
                    isLooped = true;
                }
            }
            else
            {
                if (isLooped)
                {
                    isDone = true;
                }
                CheckBiggestGap(biggestUntriggeredGapSensors, untriggeredGapSensors);
            }
        }
        
        if (biggestUntriggeredGapSensors.Count > 3)
        {
            var a = biggestUntriggeredGapSensors.First();
            a.Mark();
            var b = biggestUntriggeredGapSensors.Last();
            b.Mark();
            var middlePoint = biggestUntriggeredGapSensors[biggestUntriggeredGapSensors.Count / 2];
            middlePoint.Mark();
            Debug.Log(middlePoint);

            return new HangingResult()
            {
                Position = (a.transform.position + b.transform.position + middlePoint.transform.position) / 3,
                Rotation = middlePoint.transform.rotation.eulerAngles
            };
        }
        return null;
    }

    private static void CheckBiggestGap(List<TouchSensor> biggestUntriggeredGapSensors, List<TouchSensor> untriggeredGapSensors)
    {

        if (untriggeredGapSensors.Count > biggestUntriggeredGapSensors.Count)
        {
            biggestUntriggeredGapSensors.Clear();
            biggestUntriggeredGapSensors.AddRange(untriggeredGapSensors);
        }
        untriggeredGapSensors.Clear();
    }


}
    public class HangingResult
    {
        public Vector3 Rotation;
        public Vector3 Position;
    }
