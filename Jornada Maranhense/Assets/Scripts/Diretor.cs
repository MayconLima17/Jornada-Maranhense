using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{
    [SerializeField]
    private GameObject imagemGameOver;
    [SerializeField]
    private AudioSource somDeFundo;
    [SerializeField]
    private AudioSource audioGameOver; 
    private Pomba pomba;
    private Pontuacao pontuacao;

    private void Start()
    {
        this.pomba = GameObject.FindObjectOfType<Pomba>();
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        this.imagemGameOver.SetActive(true);
        this.somDeFundo.Stop(); 
        this.audioGameOver.Play(); 
    }

    public void ReiniciarJogo()
    {
        this.imagemGameOver.SetActive(false);
        Time.timeScale = 1;
        this.pomba.Reiniciar();
        this.DestruirObstaculos();
        this.somDeFundo.Play();
        this.pontuacao.Reiniciar(); // Corrigido com os parênteses
    }

    private void DestruirObstaculos()
    {
        Obstaculo[] obstaculos = GameObject.FindObjectsOfType<Obstaculo>();
        foreach (Obstaculo obstaculo in obstaculos)
        {
            obstaculo.Destruir();
        }
    }
}
