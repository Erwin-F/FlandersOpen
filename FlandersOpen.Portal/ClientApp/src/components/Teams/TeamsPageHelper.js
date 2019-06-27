import assign from "object-assign";
import teamApi from "../../api/teamApi";
import { showToastrError, showToastrSuccess, showToastrWarning } from "../../util/toastr";

export default class CompetitionsPageHelper {
    constructor(pageContext) {
        this.context = pageContext;
        this.appContext = pageContext.context;
    }

    init() {
        this.appContext.ajaxStarted();
        teamApi.getall()
            .then((response) => {
                this.appContext.ajaxEnded();
                const data = response.data;
                const teams = data.result;

                if (teams) {
                    this.context.setState({ teams: teams });
                } else {
                    showToastrError(data.errorMessage);
                }
            })
            .catch((ex) => {
                this.appContext.ajaxEnded();
                showToastrError(ex);
            });
    }
}