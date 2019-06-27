import Axios from "axios";

const routePrefix = "api/competition";

const competitionApi = {
    getall(){
        const url = routePrefix;
        return Axios.get(url);
    },
    create(competition){
        const url = routePrefix;
        return Axios.post(
            url,
           competition,
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            });
    },
    update(competition){
        const url = routePrefix + "/" + competition.id;
        return Axios.put(
            url,
           competition,
            {
                headers: {                    
                    'Content-Type': 'application/json'
                }
            });
    },
    delete(competitionId){
        const url = routePrefix + "/" + competitionId;
        return Axios.delete(url);
    }
};

export default competitionApi;