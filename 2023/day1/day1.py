
import sys

dict = {
  "one": "1",
  "two": "2",
  "three": "3",
  "four": "4",
  "five": "5",
  "six": "6",
  "seven": "7",
  "eight": "8",
  "nine": "9"
}

f = open(sys.argv[1], "r")
lines = f.readlines()

result = 0
# for line in lines:
for a in range(0, len(lines)):
    line = lines[a]
    numbers = []
    for i in range(0, len(line) - 1):
        char = line[i]
        try:
            int(char)
            numbers.append(char)
        except Exception:
            print("")

        for j in range(1,len(line) - i):
            slice = line[i:i+j]
            if slice in dict:
                numbers.append(dict[slice])

    print(numbers[0] + numbers[len(numbers) - 1])
    result += int(numbers[0] + numbers[len(numbers) - 1])

print(result)