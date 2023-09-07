#include <TMCStepper.h>         // TMCstepper - https://github.com/teemuatlut/TMCStepper
#include <SoftwareSerial.h>     // Software serial for the UART to TMC2209 - https://www.arduino.cc/en/Reference/softwareSerial
#include <Streaming.h>          // For serial debugging output - https://www.arduino.cc/reference/en/libraries/streaming/


#define EN_PIN           38 // Enable
#define DIR_PIN          55 // Direction
#define STEP_PIN         54 // Step
#define CS_PIN           42 // Chip select
#define SW_MOSI          66 // Software Master Out Slave In (MOSI)
#define SW_MISO          44 // Software Master In Slave Out (MISO)
#define SW_SCK           64 // Software Slave Clock (SCK)
#define SW_RX            63 // TMC2208/TMC2224 SoftwareSerial receive pin
#define SW_TX            40 // TMC2208/TMC2224 SoftwareSerial transmit pin
#define SERIAL_PORT Serial1 // TMC2208/TMC2224 HardwareSerial port
#define DRIVER_ADDRESS 0b11 // TMC2209 Driver address according to MS1 and MS2
#define R_SENSE 0.11f // Match to your driver
#define MICROSTEPS 16

SoftwareSerial SoftSerial(SW_RX, SW_TX);
TMC2209Stepper driver(&SoftSerial, R_SENSE, DRIVER_ADDRESS);   // Create TMC driver

int accel;
long maxSpeed;
int speedChangeDelay;
bool dir = false;
float count = 0;


//== Setup ===============================================================================

void setup() {
  Serial.begin(115200);               // initialize hardware serial for debugging
  driver.beginSerial(115200);         // Initialize UART
  
  pinMode(EN_PIN, OUTPUT);
  pinMode(STEP_PIN, OUTPUT);
  pinMode(DIR_PIN, OUTPUT);
  digitalWrite(EN_PIN, LOW);

  driver.begin();                                                                                                                                                                                                                                                                                                                            // UART: Init SW UART (if selected) with default 115200 baudrate
  driver.toff(5);
  driver.rms_current(500);
  driver.microsteps(MICROSTEPS);
  driver.en_spreadCycle(false);
  driver.pwm_autoscale(true);         // Needed for stealthChop
  driver.shaft(true);
}

//== Loop =================================================================================
void loop() {

  if(Serial.available()){
    rotate(Serial.parseFloat());
  }
}

void rotate(float degrees){
  Serial.println(degrees);
  const uint16_t steps = (degrees / 1.8) * MICROSTEPS;

  for (uint16_t i = steps; i>0; i--) {
    digitalWrite(STEP_PIN, HIGH);
    delayMicroseconds(1000);
    digitalWrite(STEP_PIN, LOW);
    delayMicroseconds(1000);
  }

  delay(1000);

  Serial.println("Done rotating");
}