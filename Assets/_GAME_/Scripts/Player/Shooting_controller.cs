using UnityEngine;
//using sleep
using TMPro;

public class Shooting_Controller : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private Camera maincam;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletTransform;

    // 1. Crie um campo para a referência do Animator do jogador.
    [SerializeField] private Animator playerAnimator;

    [Header("Configurações")]
    [SerializeField] private float timeBetweenShoot;

    private float timer;
    private bool canShoot;
    private Vector3 mousePos;

    void Start()
    {
        // Validação crucial para evitar erros futuros.
        if (playerAnimator == null)
        {
            Debug.LogError("O Animator do Player não foi atribuído no Inspector do objeto 'Aim'!");
        }
        canShoot = true;
    }


    void Update()
    {
        // Lógica de Mira
        mousePos = maincam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;

        // Lógica de Cooldown
        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenShoot)
            {
                canShoot = true;
            }
        }

        // Lógica de Tiro (Simplificada)
        if (Input.GetMouseButton(0) && canShoot)
        {
            playerAnimator.SetTrigger("Shot");

            for (int i = 0; i < 10000; i++) { } // Delay bobo para a animação de tiro começar
            canShoot = false;
            timer = 0;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);

            // 3. Use a referência direta e garantida.
        }
    }
}