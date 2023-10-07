import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrls: ['./all-users.component.css']
})
export class AllUsersComponent implements OnInit {

  constructor(private http: HttpClient) { }

  users: any;

  ngOnInit() {
    this.http.get<any>('https://localhost:7019/users').subscribe(res => {
        this.users = res;
    })
  }
}
