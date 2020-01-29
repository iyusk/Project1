using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GameSkript : MonoBehaviour
{
    [SerializeField]
    public GameObject Ans1;
    public GameObject Ans2;
    public GameObject Ans3;
    public GameObject Ans4;
    public GameObject Quest;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject EndobjText;
    private Rigidbody _rb;
    private int _score = 0;
    private int _niescore = 0;
    private int _countquestion = -1;
    public string[,] Question = {
 {"Które polecenie wyświetli katalog, w którym aktualnie znajduje się użytkownik?","pwd","ps","pd","cd","dir"}, { "W jaki sposób tłumaczona jest nazwa aplikacji, która umożliwia uruchamianie programów napisanych dla systemu Windows w systemie Linux?","Wine ","Potato","Emulacja okna","Malina","Boot"},
{ "Jak sprawdzić, czy proces działa bez użycia narzędzi top lub htop?","ps","prcs","ptop","cat /.prcslist","To jest niemożliwe"},
{ "Przejdźmy do następnego pytania.  Co musisz kliknąć, aby zapisać plik w popularnym edytorze konsoli Nano?","^O","Ctrl + S","Space","Enter"," ^S"},
{ "Który z tych znaków nazywany jest „potokiem” i jest zaangażowany w przekierowywanie wyjścia jednego programu na wejście innego?","|",">","%","@","Malina"},
{ "Które z poniższych poleceń pozwalają ci wyjść z Vim?","Konieczne jest odłączenie komputera poprzez wyciągnięcie drutu z gniazdka.","^X","Command: close","Command: cls","Command: exit -vim" },
{ "Które z poniższych poleceń wyświetli liczbę wierszy w pliku tproger.txt?","wc -l tproger.txt","strc tproger.txt","cat -str tproger.txt","count -str tproger.txt","Malina"},
{ "Do czego służy narzędzie grep w Linuksie?","Do pracy z wyrażeniami regularnymi.","Aby posortować zawartość pliku.","Aby przenieść plik.","Aby zarchiwizować plik.","Malina" },
{ "Które polecenie wyświetla zawartość katalogu / etc?", "ls / etc", "ls", "pwd","pwd / etc","cd / etc"},
{ "Które polecenie tworzy katalog testowy w bieżącym katalogu?","mkdir ./test","mkdir / test","newdir / test","newdir / test","Malina"},
{ "Jak wyjść z trybu superużytkownika?","exit","close","Ctrl + Z","disconnect","Ctrl + C"},
{ "Jakiego znaku lub znaków używa się do przekierowania standardowego wyjścia na koniec istniejącego pliku?",">>",">","<","<<","|"},
{ "Który program zmienia uprawnienia do plików?","chmod","su","sudo","chown","chgrp"},
{ "Który program wyświetla uruchomione procesy?","ps","kill","jobs","bg","fd" },{ " "," "," "," "," "," "},{ " "," "," "," "," "," "} };
    void Start()
    {
        RandQuest();
        _rb = gameObject.GetComponent<Rigidbody>();
    }
    private void OnCollisionStay(Collision collision)
    {
        if(Input.GetKey(KeyCode.Space) && collision.gameObject.name == "Plane")
        {
            _rb.AddForce(Vector3.up * 2 ,ForceMode.Impulse);
        }
    }
    void Nextlevel()
    {
        RandQuest();
    }
    void RandQuest()
    {
        _countquestion++;
        if (_countquestion == 13)EndGame();
        Quest.GetComponent<Text>().text = Question[_countquestion, 0];
        string[] a = { " ", Question[_countquestion, 2], Question[_countquestion, 3], Question[_countquestion, 4] , Question[_countquestion, 1] };
        int b = UnityEngine.Random.Range(1,3);a[0] = a[b];a[b] = a[4];
        Ans1.GetComponent<Text>().text = a[0];
        Ans2.GetComponent<Text>().text = a[1];
        Ans3.GetComponent<Text>().text = a[2];
        Ans4.GetComponent<Text>().text = a[3];

    }
    public void ButtonSpr1()
    {
        if (Ans1.GetComponent<Text>().text == Question[_countquestion, 1]) { Nextlevel(); _score++; } else { Nextlevel();_niescore++; };
        transform.position = new Vector3(0f, 1.2f, -5f);
    }
    public void ButtonSpr2()
    {
        if (Ans2.GetComponent<Text>().text == Question[_countquestion, 1]) { Nextlevel(); _score++; } else { Nextlevel();_niescore++; };
        transform.position = new Vector3(0f, 1.2f, -5f);
    }
    public void ButtonSpr3()
    {
        if (Ans3.GetComponent<Text>().text == Question[_countquestion, 1]) { Nextlevel(); _score++; } else { Nextlevel();_niescore++; };
        transform.position = new Vector3(0f, 1.2f, -5f);
    }
    public void ButtonSpr4()
    {
        if (Ans4.GetComponent<Text>().text == Question[_countquestion, 1]) { Nextlevel(); } else { Nextlevel();_niescore++; };
        transform.position = new Vector3(0f, 1.2f, -5f);
    }
    void Update()
    {
            if (Input.GetKey(KeyCode.W))
            {
                _rb.AddForce(new Vector3(0, 0, 10) * Time.deltaTime, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.D))
            {
                _rb.AddForce(new Vector3(10, 0, 0) * Time.deltaTime, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.A))
            {
                _rb.AddForce(new Vector3(-10, 0, 0) * Time.deltaTime, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.S))
            {
                _rb.AddForce(new Vector3(0, 0, -10) * Time.deltaTime, ForceMode.Impulse);
            }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Answ1")
        {
            ButtonSpr1();
        }
        if (other.gameObject.name == "Answ2")
        {
            ButtonSpr2();
        }
        if (other.gameObject.name == "Answ3")
        {
            ButtonSpr3();
        }
        if (other.gameObject.name == "Answ4")
        {
            ButtonSpr4();
        }
    }
    public void EndGame()
    {
        EndobjText.GetComponent<Text>().text = "Niepoprewnie :" + _niescore.ToString() + "                               Poprawnie :" + _score.ToString();
        obj1.SetActive(false);
        obj2.SetActive(true);
        _countquestion = 0;
    }
}
