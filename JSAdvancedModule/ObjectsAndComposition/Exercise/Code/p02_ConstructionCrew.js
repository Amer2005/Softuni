function solve(worker)
{
    if(worker.dizziness === true)
    {
        worker.levelOfHydrated += worker.weight * worker.experience * 0.1;
    }

    return worker;
}

console.log(solve({ weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true }
  
  ));