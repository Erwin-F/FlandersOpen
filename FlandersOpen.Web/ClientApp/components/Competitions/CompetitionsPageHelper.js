import assign from "object-assign";
import competitionApi from "../../api/competitionApi";
import { showToastrError, showToastrSuccess, showToastrWarning } from "../../util/toastr";

export default class CompetitionsPageHelper {
    constructor(context) {
        this.context = context;
        this.appContext = context.props.appContext;
    }

    init() {
        this.appContext.ajaxStarted();
        competitionApi.getall()
            .then((response) => {
                this.appContext.ajaxEnded();
                const data = response.data;
                const competitions = data.result;

                if (competitions) {
                    this.context.setState({ competitions: competitions });
                } else {
                    showToastrError(data.errorMessage); 
                }
            })
            .catch((ex) => {
                this.appContext.ajaxEnded();
                showToastrError(ex); 
            });
    }

    deleteCompetition(id){
        competitionApi.delete(id)
            .then((response) => {
                this.appContext.ajaxEnded();

                const competitions = this.context.state.competitions.filter(competition => competition.id !== id);
                this.context.setState({ competitions: competitions });
            })
            .catch((ex) => {
                this.appContext.ajaxEnded();
                showToastrError(ex); 
            });
    }
}