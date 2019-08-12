using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadpoolHealth : MonoBehaviour {
    
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;//dzwiek smierci
    public float flashScreenSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f); //czerwony
    
    public GameObject MenuUI;

    Animator anim;
    AudioSource playerAudio; // dzwiek bólu
    DeadpoolMovement deadpoolMovement; //referencja do klasy deadpool movement
    Weapon shooting;
    
    bool isDead;
    bool damaged;

    

    void Awake() // zawsze sie odbywa
    {

        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        deadpoolMovement = GetComponent<DeadpoolMovement>();
        shooting = GetComponentInChildren<Weapon>();
        currentHealth = startingHealth;
        MenuUI = GameObject.FindGameObjectWithTag("UI");
       


    }

    void Update()
    { // swiecenie ekranem przy otrzymywaniu obrazen
        if(damaged)
        {

            damageImage.color = flashColour;

        }else
        {

            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashScreenSpeed * Time.deltaTime);
        }

        damaged = false;

    }

    public void TakeDamage(int dmg)
    {
        damaged = true;
        currentHealth = currentHealth - dmg;
        healthSlider.value = currentHealth; //zmniejszenie slajdera podobna konstrukcje trzeba bedzie zrobic dla healthpackow

        playerAudio.Play();

        if(currentHealth <= 0 && !isDead)
        {

            Death();
        }


    }


    void Death()
    {
        isDead = true;

        anim.SetTrigger("Die");// odgrywamy animacje smierci
        
        playerAudio.clip = deathClip;
        playerAudio.Play();
        deadpoolMovement.enabled = false; // wylaczenie skryptu od chodzenia
        shooting.enabled = false;           // blokada mozliwosci strzelania

    }

    // obsługa healthpackow

   public void HealthUP(int healAmount)
    {
        // funkcja do healthpackow
        if (currentHealth < startingHealth)
        {
            currentHealth = currentHealth + healAmount;
            healthSlider.value = currentHealth;
        }
    }

    

    // funkcja czekania    
    public void RestartGame()
    {
        Destroy(MenuUI);
        SceneManager.LoadScene(0); // ładujemy scene main menu

    }

    
    







}
