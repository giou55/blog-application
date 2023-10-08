import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { delay } from 'rxjs';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {

  constructor(
    private http: HttpClient,
    private route: ActivatedRoute) { }

  isLoading = false;
  user: any;
  id: any;

  ngOnInit() {
    this.route.paramMap.subscribe((params: ParamMap) => {
      this.user = null;
      this.isLoading = true;
      this.id = params.get('id');
      if (this.id){
        this.http.get<any>('https://localhost:7019/users/' + this.id)
        .pipe(delay(1000))
        .subscribe(res => {
          this.isLoading = false;
          this.user = res;
        })
      }
    })

    // this.http.get<any>('https://localhost:7019/users/1').subscribe(res => {
    //     this.user = res;
    // })
  }
}
