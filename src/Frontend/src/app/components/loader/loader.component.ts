import { ChangeDetectionStrategy, Component } from '@angular/core';
import { LoaderService } from 'src/app/services/ui/loader.service';

@Component({
    selector: 'app-loader',
    templateUrl: './loader.component.html',
    styleUrls: ['./loader.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoaderComponent {
    constructor(public loaderService: LoaderService) { }
}