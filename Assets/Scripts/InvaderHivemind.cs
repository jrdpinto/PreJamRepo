using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderHivemind : MonoBehaviour {
    [SerializeField]
    int m_totalColumns;
    [SerializeField]
    GameObject[] m_rowPrefabs;
    StandardEnemy[,] m_enemies;

    float m_stateUpdateTime = 0.7f;
    float m_stateUpdateTimer = 0;

    [SerializeField]
    int m_leftMoveIndexMax = -5, m_rightMoveIndexMax = 5;
    int m_currentMoveIndex;
    [SerializeField]
    float m_worldScale = 1;

    enum HivemindState
    {
        Left,
        Right,
        Down
    }

    HivemindState m_currentState = HivemindState.Right;

    // Use this for initialization
    void Start () {
        m_enemies = new StandardEnemy[m_rowPrefabs.Length, m_totalColumns];

        for (int row = 0; row < m_rowPrefabs.Length; ++row)
        {
            for (int column = 0; column < m_totalColumns; ++column)
            {
                GameObject prefab = m_rowPrefabs[row];
                GameObject enemy = GameObject.Instantiate(prefab);

                enemy.transform.SetParent(transform);
                enemy.name = enemy.name + " (" + row + ", " + column + ")";

                enemy.transform.localPosition = new Vector3(column * m_worldScale - m_totalColumns / 2.0f, row * m_worldScale - m_rowPrefabs.Length);

                m_enemies[row, column] = enemy.GetComponent<StandardEnemy>();
            }
        }

        m_currentMoveIndex = m_leftMoveIndexMax;
        StateUpdate();
    }
	
	// Update is called once per frame
	void Update () {
        m_stateUpdateTimer += Time.deltaTime;

        if (m_stateUpdateTimer >= m_stateUpdateTime)
        {
            StateUpdate();
            m_stateUpdateTimer = 0;
        }
    }

    void StateUpdate()
    {
        Vector3 position = transform.position;

        // Apply state
        switch (m_currentState)
        {
            case (HivemindState.Left):
                m_currentMoveIndex -= 1;
                if (m_currentMoveIndex == m_leftMoveIndexMax)
                    m_currentState = HivemindState.Down;
                break;
            case (HivemindState.Right):
                m_currentMoveIndex += 1;
                if (m_currentMoveIndex == m_rightMoveIndexMax)
                    m_currentState = HivemindState.Down;
                break;
            case (HivemindState.Down):
                // TODO- Shift hivemind down a row

                if (m_currentMoveIndex <= m_leftMoveIndexMax)
                {
                    m_currentState = HivemindState.Right;
                }
                else if (m_currentMoveIndex >= m_rightMoveIndexMax)
                {
                    m_currentState = HivemindState.Left;
                }
                break;
            default: break;
        }

        position.x = m_currentMoveIndex * m_worldScale;

        transform.position = position;
    }
}
