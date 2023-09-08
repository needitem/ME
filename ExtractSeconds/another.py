import wave
import keyboard
import pygame
import threading
import time

music_file = "Track_2.wav"
wav = wave.open(music_file, 'rb')

on_set = []
start_time = time.time()  # Record the program start time

def record_time(e):
    elapsed_time = round(time.time() - start_time, 1)
    on_set.append(elapsed_time)

keyboard.on_press_key("space", record_time)

pygame.init()
pygame.mixer.init()
pygame.mixer.music.load(music_file)
pygame.mixer.music.play()

input("Press space to record, and then press Enter when done...")

keyboard.unhook_all()

pygame.mixer.music.stop()
pygame.quit()

output_file = "Track_2.txt"  
with open(output_file, "w") as f:
    for time in on_set:
        f.write(f"{time}\n")

wav.close()

print("Recording and output complete.")
