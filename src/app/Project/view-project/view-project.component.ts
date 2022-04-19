import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { ProjService } from 'src/app/Service/proj_service';

@Component({
  selector: 'app-view-project',
  templateUrl: './view-project.component.html',
  styleUrls: ['./view-project.component.css']
})
export class ViewProjectComponent implements OnInit,OnDestroy {

  Projdata:any[]=[];
  projId: any;
  routeSub: Subscription = new Subscription;
  getIdSubs: Subscription = new Subscription;
  constructor(private route:ActivatedRoute,private projservice:ProjService) { }
  
  ngOnDestroy(): void {
    this.routeSub.unsubscribe();
    this.getIdSubs.unsubscribe();
  }

  ngOnInit(): void {

    this.routeSub = this.route.params.subscribe(params => {
      this.projId= params['id'] //get the value of id
      });

      this.getIdSubs= this.projservice.GetById(this.projId).subscribe((data)=>{
        this.Projdata.push(data);
     });
  }
  

}
