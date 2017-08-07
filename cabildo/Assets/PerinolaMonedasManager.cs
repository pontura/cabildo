﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PerinolaMonedasManager : MonoBehaviour {

    public PerinolaMoneda moneda;
    public List<PerinolaMoneda> monedas;
    private Perinola perinola;
    public Transform monedasContainer;

    public void Init()
    {
        Utils.RemoveAllChildsIn(monedasContainer);

        perinola = GetComponent<Perinola>();
        monedas.Clear();
        for (int a = 0; a < 5; a++)
            AddMoneda(PerinolaMoneda.states.PLAYER_1);
        for (int a = 0; a < 5; a++)
            AddMoneda(PerinolaMoneda.states.PLAYER_2);
        for (int a = 0; a < 5; a++)
            AddMoneda(PerinolaMoneda.states.POZO);
    }
    void AddMoneda(PerinolaMoneda.states state)
    {
        PerinolaMoneda newMoneda = Instantiate(moneda);
        newMoneda.transform.SetParent(monedasContainer);
        newMoneda.Init(perinola, state);
        monedas.Add(newMoneda);
    }
	public int GetWinner()
	{
		bool player1_has_monedas = false;
		bool player2_has_monedas = false;
		foreach (PerinolaMoneda m in monedas) {
			if (m.state == PerinolaMoneda.states.PLAYER_1)
				player1_has_monedas = true;
			else if (m.state == PerinolaMoneda.states.PLAYER_2)
				player2_has_monedas = true;
		}
		if(!player1_has_monedas)
			return 2;
		else if(!player2_has_monedas)
			return 1;
		else
			return 0;
	}
    public void SetResult(PerinolaAsset.results result)
    {
        switch(result)
        {
            case PerinolaAsset.results.TOMA_TODO: TomaTodo();  break;
            case PerinolaAsset.results.TOMA1: Toma1(); break;
            case PerinolaAsset.results.TOMA2: Toma2(); break;
            case PerinolaAsset.results.TODOS_PONEN: TodosPonen(); break;
            case PerinolaAsset.results.PON1: Pon1(); break;
            case PerinolaAsset.results.PON2: Pon2(); break;
        }
    }
    void TomaTodo()
    {
		Events.OnSFX (Data.Instance.sFXManager.cash);
        foreach(PerinolaMoneda m in monedas)
        {
            if(m.state == PerinolaMoneda.states.POZO)
            {
                if(perinola.ui.teamId == 1)
                    m.ChangeState(PerinolaMoneda.states.PLAYER_1);
                else
                    m.ChangeState(PerinolaMoneda.states.PLAYER_2);
            }
        }
    }
    void Toma1()
    {
		Events.OnSFX (Data.Instance.sFXManager.cash);
        foreach (PerinolaMoneda m in monedas)
        {
            if (m.state == PerinolaMoneda.states.POZO)
            {
                if (perinola.ui.teamId == 1)
                    m.ChangeState(PerinolaMoneda.states.PLAYER_1);
                else
                    m.ChangeState(PerinolaMoneda.states.PLAYER_2);
                return;
            }
        }
    }
    void Toma2()
    {
		Events.OnSFX (Data.Instance.sFXManager.cash);
        int total = 0;
        foreach (PerinolaMoneda m in monedas)
        {
            if (m.state == PerinolaMoneda.states.POZO)
            {
                if (perinola.ui.teamId == 1)
                    m.ChangeState(PerinolaMoneda.states.PLAYER_1);
                else
                    m.ChangeState(PerinolaMoneda.states.PLAYER_2);
                total++;
                if(total == 2)
                    return;
            }
        }
    }
    void Pon1()
    {
		Events.OnSFX (Data.Instance.sFXManager.cash);
        foreach (PerinolaMoneda m in monedas)
        {
            if (perinola.ui.teamId == 1 && m.state == PerinolaMoneda.states.PLAYER_1)
            {
                m.ChangeState(PerinolaMoneda.states.POZO);
                return;
            } else if (perinola.ui.teamId == 2 && m.state == PerinolaMoneda.states.PLAYER_2)
            {
                m.ChangeState(PerinolaMoneda.states.POZO);
                return;
            }
        }
    }
    void Pon2()
    {
		Events.OnSFX (Data.Instance.sFXManager.cash);
        int total = 0;
        foreach (PerinolaMoneda m in monedas)
        {
            if (perinola.ui.teamId == 1 && m.state == PerinolaMoneda.states.PLAYER_1)
            {
                m.ChangeState(PerinolaMoneda.states.POZO);
                total++;
                if(total==2)
                    return;
            }
            else if (perinola.ui.teamId == 2 && m.state == PerinolaMoneda.states.PLAYER_2)
            {
                m.ChangeState(PerinolaMoneda.states.POZO);
                total++;
                if (total == 2)
                    return;
            }
        }
    }
    void TodosPonen()
    {
		Events.OnSFX (Data.Instance.sFXManager.cash);
        bool team1Ready = false;
        bool team2Ready = false;
        foreach (PerinolaMoneda m in monedas)
        {
            if (!team1Ready && m.state == PerinolaMoneda.states.PLAYER_1)
            {
                m.ChangeState(PerinolaMoneda.states.POZO);
                team1Ready = true;
            }
            else if (!team2Ready && m.state == PerinolaMoneda.states.PLAYER_2)
            {
                m.ChangeState(PerinolaMoneda.states.POZO);
                team2Ready = true;
            }
        }
    }
	public void Restart()
	{
		foreach (PerinolaMoneda m in monedas)
		{
			if (m.state == PerinolaMoneda.states.PLAYER_1)
			{
				m.ChangeState(PerinolaMoneda.states.POZO);
			}
			else if (m.state == PerinolaMoneda.states.PLAYER_2)
			{
				m.ChangeState(PerinolaMoneda.states.POZO);
			}
		}
	}
}
