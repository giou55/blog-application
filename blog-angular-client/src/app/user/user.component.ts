import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {

  constructor(
    private http: HttpClient,
    private route: ActivatedRoute) { }

  user: any;
  id: any;

  ngOnInit() {
    this.route.paramMap.subscribe((params: ParamMap) => {
      this.id = params.get('id');
      this.http.get<any>('https://jsonplaceholder.typicode.com/users/'+this.id).subscribe(res => {
        this.user = res;
      })
    })

    // this.http.get<any>('https://localhost:7019/users/1').subscribe(res => {
    //     this.user = res;
    // })
  }
}
