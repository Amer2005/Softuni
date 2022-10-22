class footballTeam{
    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }

    newAdditions(footballPlayers) {
        let names = [];

        for(let playerIndx in footballPlayers){
            let playerArgs = footballPlayers[playerIndx].split('/');

            if(!this.invitedPlayers.some(p => p.name == playerArgs[0])){
                this.invitedPlayers.push({
                    name: playerArgs[0],
                    age: Number(playerArgs[1]),
                    playerValue: Number(playerArgs[2])
                });
            }
            else{
                let currPlayer = this.invitedPlayers.find(x => x.name === playerArgs[0]);

                currPlayer.playerValue = Math.max(Number(playerArgs[0]), currPlayer.playerValue);
            }

            if(!names.some(p => p == playerArgs[0])){
                names.push(playerArgs[0]);
            }
        }

        return `You successfully invite ${names.join(', ')}.`;
    }

    signContract(selectedPlayer) {
        let name = selectedPlayer.split('/')[0];
        let offer = Number(selectedPlayer.split('/')[1]);

        if(!this.invitedPlayers.some(p => p.name === name)){
            throw new Error(`${name} is not invited to the selection list!`)
        }

        let player = this.invitedPlayers.find(p => p.name === name);

        if(player.playerValue > offer){
            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${player.playerValue - offer} million more are needed to sign the contract!`)
        }

        player.playerValue = "Bought";

        return `Congratulations! You sign a contract with ${name} for ${offer} million dollars.`
    }

    ageLimit(name, age) {
        if(!this.invitedPlayers.some(p => p.name === name)){
            throw new Error(`${name} is not invited to the selection list!`)
        }

        let player = this.invitedPlayers.find(p => p.name === name);

        if(player.age < age) {
            if(age - player.age < 5){
                return `${name} will sign a contract for ${age - player.age} years with ${this.clubName} in ${this.country}!`;
            }
            else{
                return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`
            }
        }
        else{
            return `${name} is above age limit!`
        }
    }

    transferWindowResult(){
        let result = "Players list:" + "\n";

        let sortedPlayers = [];

        for(let currPlayer in this.invitedPlayers){
            sortedPlayers.push({ 
                name: this.invitedPlayers[currPlayer].name, playerValue: this.invitedPlayers[currPlayer].playerValue
            });
        }

        sortedPlayers.sort((a, b) => a.name.localeCompare(b.name));

        result += sortedPlayers.map(p => `Player ${p.name}-${p.playerValue}`).join('\n');

        return result;
    }
}

let fTeam = new footballTeam("Barcelona", "Spain");
 console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Kylian Mbappé/23/180", "Lionel Messi/35/50", "Pau Torres/25/52"]));



