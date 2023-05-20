using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public enum ControlMode
    {
        Keyboard,
        Buttons
    };

    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public GameObject wheelEffectObj;
        public ParticleSystem smokeParticle;
        public Axel axel;

       
    }

    public ControlMode control;

    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 50.0f;

    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;

    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    private float moveInput;
    private float steerInput;
    public bool startTimer = false;
    public float timer = 3f;

    private Rigidbody carRb;
    private AudioSource carAudio;
    public AudioClip[] engineNoises;
    public GameObject tailLight;

    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carAudio = GetComponent<AudioSource>();
        carRb.centerOfMass = _centerOfMass;
    }

   private void Update()
    {
        GetInputs();
        AnimateWheels();
        PlayAudio();
        //WheelEffects();
    }

   private void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }

    public void MoveInput(float input)
    {
        moveInput = input;
    }

    public void SteerInput(float input)
    {
        steerInput = input;
    }

   private void GetInputs()
    {
        if (control == ControlMode.Keyboard)
        {
            moveInput = Input.GetAxis("Vertical");
            steerInput = Input.GetAxis("Horizontal");
        }
    }

    private void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * 500 * maxAcceleration * Time.deltaTime;

        }
    }

    private void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    private void Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 2000 * brakeAcceleration * Time.deltaTime;
            }

           
        }
        else if(moveInput == 0)
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 1000 * brakeAcceleration * Time.deltaTime; ;
            }        } 
        else 
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque =0 ;
            }


        }
        if (moveInput < 0 || Input.GetKey(KeyCode.Space))
            tailLight.SetActive(true);
        else
            tailLight.SetActive(false);
    }

   private void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }

   private void WheelEffects()
    {
        foreach (var wheel in wheels)
        {
            //var dirtParticleMainSettings = wheel.smokeParticle.main;

            if (Input.GetKey(KeyCode.Space) && wheel.axel == Axel.Rear && wheel.wheelCollider.isGrounded == true && carRb.velocity.magnitude >= 10.0f)
            {
                wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = true;
                wheel.smokeParticle.Emit(1);
            }
            else
            {
                wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = false;
            }
        }
    }

   private void PlayAudio()
    {
        var i = 0;


        if (startTimer)
            timer += Time.deltaTime;
       

        if (moveInput == 0  && timer < 3)
        {
            startTimer = true;
            i = 2;
        }
        else if (moveInput == 0 && timer >= 3)
        {
            i = 0;
        }
        else if (moveInput > 0)
        {
            startTimer = false;
            timer = 0;
            i = 1;
        }
        carAudio.clip = engineNoises[i];
        if (!carAudio.isPlaying)
            carAudio.Play();
    }
}
