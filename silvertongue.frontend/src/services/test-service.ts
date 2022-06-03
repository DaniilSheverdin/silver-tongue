import { ITest } from "@/types/Test";
import axios from "axios";
import authHeader from './auth-header';

export class TestService{
	API_URL= process.env.VUE_APP_API_URL;

	public async getTests() : Promise<ITest[]>{
		console.log('loading tests...:',this.API_URL)
		const storedUser = localStorage.getItem('user');
  	let user = JSON.parse(storedUser ? storedUser : "");
		const config = {
    	headers: { Authorization: `Bearer ${user.token}` }
		};
		let result: any = await axios.get(`${this.API_URL}/usertest/all`, config);
		return result.data;
  }
	public async getTest(id: number){
		console.log('loading test...:',this.API_URL)
		const storedUser = localStorage.getItem('user');
  	let user = JSON.parse(storedUser ? storedUser : "");
		const config = {
    	headers: { Authorization: `Bearer ${user.token}` }
		};
		let result: any = await axios.post(this.API_URL+'/usertest/one', {"id": id}, config);
		return result.data;
	};

	public async getResult(answers: number[], testID: number){
		console.log('get result...',this.API_URL);
		const storedUser = localStorage.getItem('user');
  	let user = JSON.parse(storedUser ? storedUser : "");
		const config = {
    	headers: { Authorization: `Bearer ${user.token}` }
		};
		let result: any = await axios.post(this.API_URL+'/usertest/result', {'answers': answers, 'TestID': testID}, config);
		return result.data;
	}
}