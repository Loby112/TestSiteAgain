const baseUrl = "https://testsiterestapi.azurewebsites.net/api/TestSites"
Vue.createApp({
    data(){
        return{
            testSites: [], 
            newData: {"id":null,"name":"","waitingTime":null}, 
            idToBeDeleted: null,
            filterWord: "", 
            sortWord: "",
            updateWaitTime: {"id":0,"name":"Test","waitingTime":null}


        }
    },  
    created(){
        this.getAllTestsites("","")
    },

    methods: {
        async helperGetAndShow(url){
            try{
                const response = await axios.get(url)
                this.testSites = await response.data
            } catch (ex){
                alert(ex.message)
            }
        },

        async getAllTestsites(filter, sort){
            url = baseUrl
            if(this.filterWord != null){
                url = url + "?filter=" + filter
                if(sort != null){
                    url = url + "&sort=" + sort
                }
            }

            await this.helperGetAndShow(url)

        },

        async updateTestsite(){
            const url = baseUrl + "/" + this.updateId
            try{
                const response = await axios.put(url, this.updateWaitTime)
                this.getAllTestsites("","")
            } catch (ex) {
                alert(ex.message)
            }
        },

        jsSortByName(){
            this.testSites.sort((testsite1, testsite2) => testsite1.name.localeCompare(testsite2.name))
        },

        jsSortByTime(){
            this.testSites.sort((testsite1, testsite2) => testsite1.waitingTime - testsite2.waitingTime)
        }
        
        


    }






}).mount('#app')