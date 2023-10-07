import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private http: HttpClient) { }

  users: any;

  ngOnInit() {
    this.http.get<any>('https://localhost:7019/users').subscribe(res => {
        this.users = res;
        console.log(res);
    })
  }
}
