class Display:

    def __init__():
        top: 0

    def draw_name(self):
        draw.rectangle((0, 0, width, height), outline=0, fill=0)
        draw.text((x, top), "Pao-Stat Version 1.0", font=font, fill=255)

    def draw_tempt(self, temp):
        draw.rectangle((0, top+10, width, 12), outline=0, fill=0)
        draw.text((x, top + 10), "Current Temperature: {temp}*F")
