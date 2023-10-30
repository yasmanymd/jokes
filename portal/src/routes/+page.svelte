<script>
	import {
		Button,
		Card,
		CardBody,
		CardTitle,
		Ribbon,
		El,
		Icon,
		Table,
		TableBody,
		TableCell,
		TableHead,
		TableRow
	} from 'yesvelte';
	import { writable } from 'svelte/store';
	import { onMount } from 'svelte';

	let randomQuote = 'Loading...';
	let quotes = writable([]);

	function getRandom() {
		fetch('http://localhost:3000/api/Jokes/GetRandom')
			.then((response) => response.json())
			.then((data) => {
				randomQuote = data.value;
			})
			.catch((error) => {
				console.log(error);
			});
	}

	function getQuotes() {
		fetch('http://localhost:3000/api/Jokes/GetJokes')
			.then((response) => response.json())
			.then((data) => {
				quotes.set(data);
			})
			.catch((error) => {
				console.log(error);
			});
	}

	onMount(async () => {
		getRandom();
		getQuotes();
	});
</script>

<h1 style="text-align: center; margin-top: 20px; margin-bottom: 10px;">Welcome to My Example</h1>

<El container>
	<El row>
		<El col="9">
			<Table hover>
				<TableHead>
					<TableRow>
						<TableCell>Id</TableCell>
						<TableCell>Quote</TableCell>
						<TableCell>Created at</TableCell>
					</TableRow>
				</TableHead>
				<TableBody>
					{#each $quotes as quote}
						<TableRow>
							<TableCell>{quote.id}</TableCell>
							<TableCell>{quote.value}</TableCell>
							<TableCell>{quote.createdAt}</TableCell>
						</TableRow>
					{/each}
				</TableBody>
			</Table>
		</El>
		<El col="3">
			<El row>
				<El colSm="12" colMd="12">
					<Card>
						<CardBody>
							<CardTitle>Joke of Day</CardTitle>
							<p>
								{randomQuote}
							</p>
							<Button
								color="primary"
								on:click={async () => {
									getRandom();
								}}>Get another one</Button
							>
						</CardBody>
						<Ribbon bgColor="success" elementPosition="end"
							><Icon name="bell" color="light" />
						</Ribbon>
					</Card>
				</El>
			</El>
		</El>
	</El>
</El>
