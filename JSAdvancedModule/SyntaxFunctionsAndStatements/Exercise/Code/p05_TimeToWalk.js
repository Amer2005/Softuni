function calculateTimeToWalk(steps, stepLength, speed)
{
    let distance = steps * stepLength;

    let time = 0;

    time += Math.floor(distance / 500) * 60;

    if(distance % 500 == 0)
    {
        time -= 60;
    }

    speed = speed * 1000 / 3600;

    time += distance / speed;

    let hours = Math.floor(time / 3600);

    time %= 3600;

    let minutes = Math.floor(time / 60);

    time %= 60;

    let seconds = Math.round(time);

    if(hours < 10)
    {
        hours = `0${hours}`;
    }

    if(minutes < 10)
    {
        minutes = `0${minutes}`;
    }

    if(seconds < 10)
    {
        seconds = `0${seconds}`;
    }

    console.log(`${hours}:${minutes}:${seconds}`);
}