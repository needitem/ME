import wave
import keyboard
import pygame
import threading
import time

music_file = "Track_2.wav"
music_text = "Track_2.txt"
wav = wave.open(music_file, 'rb')

on_set = []
start_time = time.time()  # Record the program start time 

def record_time(e):
    elapsed_time = round(time.time() - start_time, 1)
    on_set.append(elapsed_time)

pygame.init()
pygame.mixer.init()
pygame.mixer.music.load(music_file)
pygame.mixer.music.play()
 
try:
    with open(music_text, "r") as file:
        content = file.read()
except FileNotFoundError:
    print("File not found.")
except Exception as e:
    print("An error occurred:", str(e))


for second in content.split("\n"):
    if second == "":
        continue
    time.sleep(1)
    keyboard.press_and_release("space")
    print("Pressed space at", second, "seconds.")

             
pygame.mixer.music.stop()
pygame.quit()

wav.close()
qqqq     